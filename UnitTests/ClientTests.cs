using FixedFloatApi;
using FixedFloatApi.Consts;
using FixedFloatApi.Dto;
using FixedFloatApi.Dto.Requests;
using FixedFloatApi.Dto.Response;
using FixedFloatApi.Enums;
using NUnit.Framework;
using System.Threading;
using System.Threading.Tasks;

namespace UnitTests
{

    /// ------------------------------------Important-------------------------------------------
    /// The limit per minute is 250 units of weight.
    /// A createOrder request costs 50 units of weight.All other requests by 1 unit of weight
    /// If you have more than 250 per min your API KEY will blocked
    /// ----------------------------------------------------------------------------------------
    [TestFixture]
    public class ClientTests
    {
        private static Authentication _auth;
        private const string ApiKey = "Your API Key";
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
        public void GetCurrenciesTests()
        {
            CurrenciesTestsAsserts(_client.GetCurrencies());
        }

        [Test]
        public async Task GetCurrenciesAsyncTests()
        {
            var rs = await _client.GetCurrenciesAsync();
            CurrenciesTestsAsserts(rs);
        }

        [Test]
        [TestCase("BTC", "ETH", 1)]
        [TestCase("LTC", "DOGE", 0.152)]
        public void GetPairTest(string from, string to, decimal amount)
        {
            var pair = new PairRequest(from, to, amount);
            var rs = _client.GetPair(pair);
            PairTestsAsserts(rs);
        }

        [Test]
        [TestCase("BTC", "ETH", 1)]
        [TestCase("LTC", "DOGE", 0.152)]
        public async Task GetPairAsyncTest(string from, string to, decimal amount)
        {
            var pair = new PairRequest(from, to, amount);
            var rs = await _client.GetPairAsync(pair);
            PairTestsAsserts(rs);
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
        public void GetPriceTest(string fromCurrency, string toCurrency, decimal fromQty, ExchangeType type, decimal toQty)
        {
            var price = new PriceRequest(fromCurrency, toCurrency, fromQty, type, toQty);
            PriceTestsAsserts(_client.GetPrice(price));
        }

        [Test]
        [TestCase("ltc", "Doge", 0.153, ExchangeType.Fixed, 1000)]
        [TestCase("ltc", "Doge", 1.153, ExchangeType.Float, 13)]
        public async Task GetPriceAsyncTest(string fromCurrency, string toCurrency, decimal fromQty, ExchangeType type, decimal toQty)
        {
            var price = new PriceRequest(fromCurrency, toCurrency, fromQty, type, toQty);
            var rs = await _client.GetPriceAsync(price);
            PriceTestsAsserts(rs);
        }

        [Test]
        [Description("Read important information on the top of the class")]
        [TestCase("ltc", "doge", 0.5, "DCcbT48AXJiHWsgfRrMigZDxdyEHh95H48", ExchangeType.Float, "Extra not work", 9)]
        public void CreateOrderTests(string fromCurrency, string toCurrency, decimal fromQty, string toAddress, ExchangeType type, string extra, decimal toQty)
        {
            var order = new CreateOrderRequest(fromCurrency, toCurrency, fromQty, toAddress, type, extra, toQty);

            var rs = _client.CreateOrder(order);
            Assert.AreEqual(rs.Data.To.Address, toAddress);
            Assert.AreEqual(rs.Data.To.Currency, toCurrency.ToUpper());
            Assert.AreEqual(rs.Data.From.Currency, fromCurrency.ToUpper());
            CreateOrderTestsAsserts(rs);

        }

        [Test]
        [Description("Read important information on the top of the class")]
        [TestCase("ltc", "doge", 0.152, "DCcbT48AXJiHWsgfRrMigZDxdyEHh95H48", ExchangeType.Fixed, "Extra not work", 9)]
        public async Task CreateOrderAsyncTests(string fromCurrency, string toCurrency, decimal fromQty, string toAddress, ExchangeType type, string extra, decimal toQty)
        {
            var order = new CreateOrderRequest(fromCurrency, toCurrency, fromQty, toAddress, type, extra, toQty);

            var rs = await _client.CreateOrderAsync(order);
            Assert.AreEqual(rs.Data.To.Address, toAddress);
            Assert.AreEqual(rs.Data.To.Currency, toCurrency.ToUpper());
            Assert.AreEqual(rs.Data.From.Currency, fromCurrency.ToUpper());
            CreateOrderTestsAsserts(rs);
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
        public void SetEmergencyTest()
        {
            var em = new EmergencyRequest("Your Valid Id", "Your Valid token");
            var rs = _client.SetEmergency(em);
            EmergencyTestsAsserts(rs);
        }

        [Test]
        public async Task SetEmergencyAsyncTest()
        {
            var em = new EmergencyRequest("Your Valid Id", "Your Valid token");
            var rs = await _client.SetEmergencyAsync(em);
            EmergencyTestsAsserts(rs);
        }

        [Test]
        public void GetOrderTests()
        {
            var order = new GetOrderRequest("Your Valid Id", "Your Valid token");
            var rs = _client.GetOrder(order);
            GetOrderTestsAsserts(rs);

        }

        [Test]
        public async Task GetOrderAsyncTests()
        {
            var order = new GetOrderRequest("Your Valid Id", "Your Valid token");
            var rs = await _client.GetOrderAsync(order);
            GetOrderTestsAsserts(rs);

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


        #region //---- private functions ---

        private void CurrenciesTestsAsserts(CurrencyResponse rs)
        {
            Assert.True(rs.StatusCode == 0);
            Assert.True(rs.Msg.Equals(Messages.OK));
            Assert.True(rs.Currencies.Count > 0);
        }

        private void PairTestsAsserts(PairResponse rs)
        {
            Assert.True(rs.StatusCode == 0);
            Assert.True(rs.Msg.Equals(Messages.OK));
            Assert.NotNull(rs.Data);
        }

        private void PriceTestsAsserts(PriceResponse rs)
        {
            Assert.True(rs.StatusCode == 0);
            Assert.True(rs.Msg.Equals(Messages.OK));
            Assert.NotNull(rs.Data.To);
            Assert.NotNull(rs.Data.From);
        }

        private void CreateOrderTestsAsserts(CreateOrderResponse rs)
        {

            Assert.True(rs.StatusCode == 0);
            Assert.True(rs.Msg.Equals(Messages.OK));
            Assert.NotNull(rs.Data);
            Assert.NotNull(rs.Data.From);
            Assert.NotNull(rs.Data.To);
            Assert.False(string.IsNullOrEmpty(rs.Data.To.Address));
            Assert.False(string.IsNullOrEmpty(rs.Data.Token));
            Assert.False(string.IsNullOrEmpty(rs.Data.Id));

        }

        private void EmergencyTestsAsserts(EmergencyResponse rs)
        {
            Assert.IsTrue(rs.IsSuccessfullySet);
            Assert.AreEqual(rs.Msg, Messages.OK);
            Assert.AreEqual(rs.StatusCode, 0);
        }

        private void GetOrderTestsAsserts(GetOrderResponse rs)
        {
            Assert.True(rs.StatusCode == 0);
            Assert.True(rs.Msg.Equals(Messages.OK));
            Assert.NotNull(rs.Data);
            Assert.NotNull(rs.Data.From);
            Assert.NotNull(rs.Data.To);
        }
    
    }

    #endregion
}

