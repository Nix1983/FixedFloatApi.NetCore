using FixedFloatApi;
using FixedFloatApi.Consts;
using FixedFloatApi.Dto;
using FixedFloatApi.Dto.Requests;
using FixedFloatApi.Enums;
using NUnit.Framework;
using System.Threading;

namespace UnitTests
{

    /// -----------------Important--------------------------------------------------------------
    /// The limit per minute is 250 units of weight.
    /// A createOrder request costs 50 units of weight.All other requests by 1 unit of weight
    /// If you have more than 250 per min your API KEY will blocked
    /// ----------------------------------------------------------------------------------------
    [TestFixture]
    public class ClientTests
    {
        private static Authentication _auth;
        private const string ApiKey = "Your API KEY";
        private const string Secret = "Your Secret";
        private static FixedFloatClient _client;

        [SetUp]
        public void Setup()
        {
            if (_auth == null) _auth = new Authentication(ApiKey, Secret);
            if (_client == null) _client = FixedFloatClient.Instance(_auth);

            Thread.Sleep(1000);
        }

        [TearDown]
        public void TearDown()
        {
            _auth = new Authentication(ApiKey, Secret);
            _client = FixedFloatClient.Instance(_auth);
        }

        [Test]
        public void GetCurrenciesTests()
        {
            var rs = _client.GetCurrencies();
            Assert.True(rs.StatusCode == 0);
            Assert.True(rs.Msg.Equals(Messages.OK));
            Assert.True(rs.Currencies.Count > 0);
        }

        [Test]
        [TestCase(ApiKey, "WrongSecret")]
        [TestCase("WrongApiKey", Secret)]
        public void NoPermissionTest(string apiKey, string secret)
        {
            _auth = new Authentication(apiKey, secret);
            _client = FixedFloatClient.Instance(_auth);
            var rs = _client.GetCurrencies();
            Assert.True(rs.StatusCode == 501);
            Assert.True(rs.Msg.Equals(Messages.NotHavePermission));
            Assert.Null(rs.Currencies);
        }

        [Test]
        [TestCase("BTC", "ETH", 1)]
        [TestCase("LTC", "DOGE", 0.152)]
        [TestCase("eth", "DasH", 4)]
        [TestCase("eth", "DasH", -5)]
        [TestCase("eth", "DasH", 0)]
        public void GetPairTest(string from, string to, decimal amount)
        {
            var pair = new PairRequest(from, to, amount);
            var rs = _client.GetPair(pair);
            Assert.True(rs.StatusCode == 0);
            Assert.True(rs.Msg.Equals(Messages.OK));
            Assert.NotNull(rs.Data);
        }

        [Test]
        [TestCase("CoinNotInDataBase", "ETH", 1)]
        [TestCase("BTC", "CoinNotInDataBase", 1)]
        public void GetPairTestWithCoinsTheyNotExist(string from, string to, decimal amount)
        {
            var pair = new PairRequest(from, to, amount);
            var rs = _client.GetPair(pair);
            Assert.True(rs.StatusCode == 0);
            Assert.True(rs.Msg.Equals(Messages.PairIsNotAvailable));
            Assert.Null(rs.Data);
        }

        [Test]
        [TestCase("ltc", "Doge", 0.153, ExchangeType.Fixed, 1000)]
        [TestCase("ltc", "Doge", 1.153, ExchangeType.Float, 13)]
        [TestCase("btc", "ETH", 0.153, ExchangeType.Fixed, 0)]
        [TestCase("daSH", "ETH", 1.1231, ExchangeType.Float, 0)]
        public void GetPriceTest(string fromCurrency, string toCurrency, decimal fromQty, ExchangeType type, decimal toQty)
        {
            var price = new PriceRequest(fromCurrency, toCurrency, fromQty, type, toQty);

            var rs = _client.GetPrice(price);
            Assert.True(rs.StatusCode == 0);
            Assert.True(rs.Msg.Equals(Messages.OK));
            Assert.NotNull(rs.Data.To);
            Assert.NotNull(rs.Data.From);
        }

        [Test]
        [Description("Read important information on the top of the class")]
        [TestCase("ltc", "doge", 0.152, "DCcbT48AXJiHWsgfRrMigZDxdyEHh95H48", ExchangeType.Fixed, "Extra not work", 9)]
        [TestCase("doge", "ltc", 540, "MNFzK7SAXiRTzvQwjynsAioKectM42jev6", ExchangeType.Float, "Extra not work", 0)]
        public void CreateOrderTests(string fromCurrency, string toCurrency, decimal fromQty, string toAddress, ExchangeType type, string extra, decimal toQty)
        {
            var order = new CreateOrderRequest(fromCurrency, toCurrency, fromQty, toAddress, type, extra, toQty);

            var rs = _client.CreateOrder(order);
            Assert.True(rs.StatusCode == 0);
            Assert.True(rs.Msg.Equals(Messages.OK));
            Assert.NotNull(rs.Data);
            Assert.NotNull(rs.Data.From);
            Assert.NotNull(rs.Data.To);
            Assert.AreEqual(rs.Data.To.Address, toAddress);
            Assert.AreEqual(rs.Data.To.Currency, toCurrency.ToUpper());
            Assert.AreEqual(rs.Data.From.Currency, fromCurrency.ToUpper());
            Assert.False(string.IsNullOrEmpty(rs.Data.To.Address));
            Assert.False(string.IsNullOrEmpty(rs.Data.Token));
            Assert.False(string.IsNullOrEmpty(rs.Data.Id));

        }

        [Test]
        public void SetEmergencyTestShouldFail()
        {
            var em = new EmergencyRequest("IsNotValid", "IsNotValid");
            var rs = _client.SetEmergency(em);
            Assert.False(rs.IsSuccessfullySet);
            Assert.AreEqual(rs.Msg, Messages.NotHavePermission);
            Assert.AreEqual(rs.StatusCode, 501);

        }

        [Test]
        [Ignore("Without valid id and token, test will fail")]
        public void SetEmergencyTest()
        {
            var em = new EmergencyRequest("Your Valid Id", "Your Valid token");
            var rs = _client.SetEmergency(em);
            Assert.IsTrue(rs.IsSuccessfullySet);
            Assert.AreEqual(rs.Msg, Messages.OK);
            Assert.AreEqual(rs.StatusCode, 0);

        }

        [Test]
        //[Ignore("Without valid id and token, test will fail")]
        public void GetOrderTests()
        {
            var order = new GetOrderRequest("EG598W", "ksQsUMY7KLeyXrEXkz58R1RKtiLA49ScRxBx7Fh5");
            var rs = _client.GetOrder(order);
            Assert.True(rs.StatusCode == 0);
            Assert.True(rs.Msg.Equals(Messages.OK));
            Assert.NotNull(rs.Data);
            Assert.NotNull(rs.Data.From);
            Assert.NotNull(rs.Data.To);

        }

        [Test]
        public void GetOrderTestsShouldFail()
        {
            var order = new GetOrderRequest("IsNotValid", "IsNotValid");
            var rs = _client.GetOrder(order);
            Assert.IsNull(rs.Data);
            Assert.AreEqual(rs.Msg, Messages.NotHavePermission);
            Assert.AreEqual(rs.StatusCode, 501);

        }
    }
}
