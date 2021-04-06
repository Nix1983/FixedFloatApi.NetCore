using FixedFloatApi.Dto.Requests;
using FixedFloatApi.Enums;
using NUnit.Framework;
using System;

namespace UnitTests
{
    [TestFixture]
    class RequestDtoTests
    {
        [Test]
        public void PriceRequestNormalConstructorTest()
        {
            var obj = new PriceRequest("btc", "eth", 0.1m);
            Assert.AreEqual("btc", obj.FromCurrency);
            Assert.AreEqual("eth", obj.ToCurrency);
            Assert.AreEqual(0.1, obj.FromQty);
            Assert.AreEqual(0, obj.ToQty);
            Assert.AreEqual(ExchangeType.Float, obj.Type);

            obj = new PriceRequest(null, null, 0);
            Assert.AreEqual(string.Empty, obj.FromCurrency);
            Assert.AreEqual(string.Empty, obj.ToCurrency);
            Assert.AreEqual(0.1, obj.FromQty);
            Assert.AreEqual(0, obj.ToQty);
            Assert.AreEqual(ExchangeType.Float, obj.Type);

            obj = new PriceRequest("doge", "grs", 0, ExchangeType.Fixed, 1);
            Assert.AreEqual("doge", obj.FromCurrency);
            Assert.AreEqual("grs", obj.ToCurrency);
            Assert.AreEqual(0.1, obj.FromQty);
            Assert.AreEqual(1, obj.ToQty);
            Assert.AreEqual(ExchangeType.Fixed, obj.Type);

        }

        [Test]
        public void PriceRequestShortConstructorTest()
        {
            var pair = new PairRequest("btc", "eth", 0.1m);
            var obj = new PriceRequest(pair);
            Assert.AreEqual("btc", obj.FromCurrency);
            Assert.AreEqual("eth", obj.ToCurrency);
            Assert.AreEqual(0.1, obj.FromQty);
            Assert.AreEqual(0, obj.ToQty);
            Assert.AreEqual(ExchangeType.Float, obj.Type);

            pair = new PairRequest(null, null, 0);
            obj = new PriceRequest(pair);
            Assert.AreEqual(string.Empty, obj.FromCurrency);
            Assert.AreEqual(string.Empty, obj.ToCurrency);
            Assert.AreEqual(0.1, obj.FromQty);
            Assert.AreEqual(0, obj.ToQty);
            Assert.AreEqual(ExchangeType.Float, obj.Type);

            pair = new PairRequest("doge", "grs", 0);
            obj = new PriceRequest(pair, ExchangeType.Fixed);
            Assert.AreEqual("doge", obj.FromCurrency);
            Assert.AreEqual("grs", obj.ToCurrency);
            Assert.AreEqual(0.1, obj.FromQty);
            Assert.AreEqual(0, obj.ToQty);
            Assert.AreEqual(ExchangeType.Fixed, obj.Type);

        }

        [Test]
        public void PairRequestNormalConstructorTest()
        {
            var obj = new PairRequest("btc", "eth", 0.1m);
            Assert.AreEqual("btc", obj.FromCurrency);
            Assert.AreEqual("eth", obj.ToCurrency);
            Assert.AreEqual(0.1, obj.FromQty);

            obj = new PairRequest(null, null, 0);
            Assert.AreEqual(string.Empty, obj.FromCurrency);
            Assert.AreEqual(string.Empty, obj.ToCurrency);
            Assert.AreEqual(0, obj.FromQty);

        }

        [Test]
        public void PairRequestShortConstructorTest()
        {
            var price = new PriceRequest("btc", "eth", 0.1m);
            var obj = new PairRequest(price);
            Assert.AreEqual("btc", obj.FromCurrency);
            Assert.AreEqual("eth", obj.ToCurrency);
            Assert.AreEqual(0.1, obj.FromQty);

            price = new PriceRequest(null, null, 0);
            obj = new PairRequest(price);
            Assert.AreEqual(string.Empty, obj.FromCurrency);
            Assert.AreEqual(string.Empty, obj.ToCurrency);
            Assert.AreEqual(0.1, obj.FromQty);

        }

        [Test]
        public void GetOrderRequestConstructorTest()
        {
            var obj = new GetOrderRequest("5345345", "fg45w24g5245g");
            Assert.AreEqual("5345345", obj.Id);
            Assert.AreEqual("fg45w24g5245g", obj.Token);


            obj = new GetOrderRequest(null, null);
            Assert.AreEqual(string.Empty, obj.Id);
            Assert.AreEqual(string.Empty, obj.Token);

        }

        [Test]
        public void EmergencytRequestConstructorTest()
        {
            var obj = new EmergencyRequest("5345345", "fg45w24g5245g");
            Assert.AreEqual("5345345", obj.Id);
            Assert.AreEqual("fg45w24g5245g", obj.Token);
            Assert.AreEqual(string.Empty, obj.Address);
            Assert.AreEqual(Emergency.EXCHANGE, obj.Choice);


            obj = new EmergencyRequest("5345345", "fg45w24g5245g", Emergency.REFUND, "RefundAdress");
            Assert.AreEqual("5345345", obj.Id);
            Assert.AreEqual("fg45w24g5245g", obj.Token);
            Assert.AreEqual("RefundAdress", obj.Address);
            Assert.AreEqual(Emergency.REFUND, obj.Choice);

            obj = new EmergencyRequest(null, null, Emergency.NONE, null);
            Assert.AreEqual(string.Empty, obj.Id);
            Assert.AreEqual(string.Empty, obj.Token);
            Assert.AreEqual(string.Empty, obj.Address);
            Assert.AreEqual(Emergency.NONE, obj.Choice);

        }

        [Test]
        public void EmergencytRequestConstructorTestShouldThrowException()
        {
            Assert.Throws<Exception>(() => new EmergencyRequest("5345345", "fg45w24g5245g", Emergency.REFUND));

        }

        [Test]
        public void CreateOrdertRequestNormalConstructorTest()
        {
            var obj = new CreateOrderRequest("btc", "eth", 0.1m, "Address");
            Assert.AreEqual("btc", obj.FromCurrency);
            Assert.AreEqual("eth", obj.ToCurrency);
            Assert.AreEqual(0.1, obj.FromQty);
            Assert.AreEqual(0, obj.ToQty);
            Assert.AreEqual(ExchangeType.Float, obj.Type);
            Assert.AreEqual("Address", obj.ToAddress);

            obj = new CreateOrderRequest(null, null, 0,null,ExchangeType.Float,"extra",1);
            Assert.AreEqual(string.Empty, obj.FromCurrency);
            Assert.AreEqual(string.Empty, obj.ToCurrency);
            Assert.AreEqual(0, obj.FromQty);
            Assert.AreEqual(1, obj.ToQty);
            Assert.AreEqual(ExchangeType.Float, obj.Type);
            Assert.AreEqual(string.Empty, obj.ToAddress);
            Assert.AreEqual("extra", obj.Extra);

            obj = new CreateOrderRequest(null, null, 0.2132323m, null, ExchangeType.Float, null, 1);
            Assert.AreEqual(string.Empty, obj.FromCurrency);
            Assert.AreEqual(string.Empty, obj.ToCurrency);
            Assert.AreEqual(0.2132323m, obj.FromQty);
            Assert.AreEqual(1, obj.ToQty);
            Assert.AreEqual(ExchangeType.Float, obj.Type);
            Assert.AreEqual(string.Empty, obj.ToAddress);
            Assert.AreEqual(string.Empty, obj.Extra);

        }

        [Test]
        public void CreateOrdertRequestShortConstructorTest()
        {
            var price = new PriceRequest("btc", "eth", 1);
            var obj = new CreateOrderRequest(price, "Address");
            Assert.AreEqual("btc", obj.FromCurrency);
            Assert.AreEqual("eth", obj.ToCurrency);
            Assert.AreEqual(1, obj.FromQty);
            Assert.AreEqual(0, obj.ToQty);
            Assert.AreEqual(ExchangeType.Float, obj.Type);
            Assert.AreEqual("Address", obj.ToAddress);

            price = new PriceRequest(null, null, 0);
            obj = new CreateOrderRequest(price, null, ExchangeType.Fixed);
            Assert.AreEqual(string.Empty, obj.FromCurrency);
            Assert.AreEqual(string.Empty, obj.ToCurrency);
            Assert.AreEqual(0.1, obj.FromQty);
            Assert.AreEqual(0, obj.ToQty);
            Assert.AreEqual(ExchangeType.Fixed, obj.Type);
            Assert.AreEqual(string.Empty, obj.ToAddress);
            Assert.AreEqual(string.Empty, obj.Extra);

            
        }
    }
}
