using FixedFloatApi.Dto.Response;
using FixedFloatApi.Enums;
using Newtonsoft.Json;
using NUnit.Framework;

namespace UnitTests
{
    [TestFixture]
    public class ConverterTests
    {
        #region //---- test data ----
        private const string ExchangeStatus0 = "{\"code\":0,\"msg\":\"OK\",\"data\":{\"id\":\"EG598W\",\"from\":{\"currency\":\"LTC\",\"symbol\":\"LTC\",\"subSymbol\":\"\",\"network\":\"LTC\",\"name\":\"Litecoin\",\"alias\":\"litecoin\",\"qty\":\"0.15200000\",\"amount\":\"0.15200000\",\"address\":\"MEp3ibDGRmDsUB8b4dSJ52MV9Y1Bdec532\",\"extra\":\"\",\"tx\":{\"id\":null,\"amount\":null,\"fee\":null,\"ccyfee\":null,\"time\":false,\"timeBlock\":false,\"confirmations\":null}},\"to\":{\"currency\":\"DOGE\",\"symbol\":\"DOGE\",\"subSymbol\":\"\",\"network\":\"DOGE\",\"name\":\"Dogecoin\",\"alias\":\"dogecoin\",\"qty\":\"527.61000000\",\"amount\":\"527.61000000\",\"address\":\"DCcbT48AXJiHWsgfRrMigZDxdyEHh95H48\",\"extra\":\"\",\"tx\":{\"id\":null,\"amount\":null,\"fee\":null,\"ccyfee\":null,\"time\":false,\"timeBlock\":false,\"confirmations\":null}},\"back\":{\"currency\":\"\",\"symbol\":null,\"subSymbol\":null,\"network\":null,\"name\":null,\"alias\":null,\"qty\":\"0.00000000\",\"amount\":\"0.00000000\",\"address\":\"\",\"extra\":\"\",\"tx\":{\"id\":null,\"amount\":null,\"fee\":null,\"ccyfee\":null,\"time\":false,\"timeBlock\":false,\"confirmations\":null}},\"emergency\":{\"status\":[],\"choice\":\"REFUND\",\"repeat\":\"0\"},\"type\":\"fixed\",\"email\":\"\",\"rate\":3471.11842105,\"rateRev\":0.00028809,\"status\":\"0\",\"reg\":1617586255,\"start\":false,\"finish\":false,\"update\":1617586255,\"expiration\":1617586855,\"left\":414,\"step\":\"new\"}}";
        private const string ExchangeStatus1 = "{\"code\":0,\"msg\":\"OK\",\"data\":{\"id\":\"EG598W\",\"from\":{\"currency\":\"LTC\",\"symbol\":\"LTC\",\"subSymbol\":\"\",\"network\":\"LTC\",\"name\":\"Litecoin\",\"alias\":\"litecoin\",\"qty\":\"0.15200000\",\"amount\":\"0.15200000\",\"address\":\"MEp3ibDGRmDsUB8b4dSJ52MV9Y1Bdec532\",\"extra\":\"\",\"tx\":{\"id\":null,\"amount\":null,\"fee\":null,\"ccyfee\":null,\"time\":false,\"timeBlock\":false,\"confirmations\":null}},\"to\":{\"currency\":\"DOGE\",\"symbol\":\"DOGE\",\"subSymbol\":\"\",\"network\":\"DOGE\",\"name\":\"Dogecoin\",\"alias\":\"dogecoin\",\"qty\":\"527.61000000\",\"amount\":\"527.61000000\",\"address\":\"DCcbT48AXJiHWsgfRrMigZDxdyEHh95H48\",\"extra\":\"\",\"tx\":{\"id\":null,\"amount\":null,\"fee\":null,\"ccyfee\":null,\"time\":false,\"timeBlock\":false,\"confirmations\":null}},\"back\":{\"currency\":\"\",\"symbol\":null,\"subSymbol\":null,\"network\":null,\"name\":null,\"alias\":null,\"qty\":\"0.00000000\",\"amount\":\"0.00000000\",\"address\":\"\",\"extra\":\"\",\"tx\":{\"id\":null,\"amount\":null,\"fee\":null,\"ccyfee\":null,\"time\":false,\"timeBlock\":false,\"confirmations\":null}},\"emergency\":{\"status\":[],\"choice\":\"EXCHANGE\",\"repeat\":\"0\"},\"type\":\"float\",\"email\":\"\",\"rate\":3471.11842105,\"rateRev\":0.00028809,\"status\":\"1\",\"reg\":1617586255,\"start\":false,\"finish\":false,\"update\":1617586255,\"expiration\":1617586855,\"left\":414,\"step\":\"new\"}}";
        private const string ExchangeStatus2 = "{\"code\":0,\"msg\":\"OK\",\"data\":{\"id\":\"EG598W\",\"from\":{\"currency\":\"LTC\",\"symbol\":\"LTC\",\"subSymbol\":\"\",\"network\":\"LTC\",\"name\":\"Litecoin\",\"alias\":\"litecoin\",\"qty\":\"0.15200000\",\"amount\":\"0.15200000\",\"address\":\"MEp3ibDGRmDsUB8b4dSJ52MV9Y1Bdec532\",\"extra\":\"\",\"tx\":{\"id\":null,\"amount\":null,\"fee\":null,\"ccyfee\":null,\"time\":false,\"timeBlock\":false,\"confirmations\":null}},\"to\":{\"currency\":\"DOGE\",\"symbol\":\"DOGE\",\"subSymbol\":\"\",\"network\":\"DOGE\",\"name\":\"Dogecoin\",\"alias\":\"dogecoin\",\"qty\":\"527.61000000\",\"amount\":\"527.61000000\",\"address\":\"DCcbT48AXJiHWsgfRrMigZDxdyEHh95H48\",\"extra\":\"\",\"tx\":{\"id\":null,\"amount\":null,\"fee\":null,\"ccyfee\":null,\"time\":false,\"timeBlock\":false,\"confirmations\":null}},\"back\":{\"currency\":\"\",\"symbol\":null,\"subSymbol\":null,\"network\":null,\"name\":null,\"alias\":null,\"qty\":\"0.00000000\",\"amount\":\"0.00000000\",\"address\":\"\",\"extra\":\"\",\"tx\":{\"id\":null,\"amount\":null,\"fee\":null,\"ccyfee\":null,\"time\":false,\"timeBlock\":false,\"confirmations\":null}},\"emergency\":{\"status\":[],\"choice\":\"NONE\",\"repeat\":\"0\"},\"type\":\"Fixed\",\"email\":\"\",\"rate\":3471.11842105,\"rateRev\":0.00028809,\"status\":\"2\",\"reg\":1617586255,\"start\":false,\"finish\":false,\"update\":1617586255,\"expiration\":1617586855,\"left\":414,\"step\":\"new\"}}";
        private const string ExchangeStatus3 = "{\"code\":0,\"msg\":\"OK\",\"data\":{\"id\":\"EG598W\",\"from\":{\"currency\":\"LTC\",\"symbol\":\"LTC\",\"subSymbol\":\"\",\"network\":\"LTC\",\"name\":\"Litecoin\",\"alias\":\"litecoin\",\"qty\":\"0.15200000\",\"amount\":\"0.15200000\",\"address\":\"MEp3ibDGRmDsUB8b4dSJ52MV9Y1Bdec532\",\"extra\":\"\",\"tx\":{\"id\":null,\"amount\":null,\"fee\":null,\"ccyfee\":null,\"time\":false,\"timeBlock\":false,\"confirmations\":null}},\"to\":{\"currency\":\"DOGE\",\"symbol\":\"DOGE\",\"subSymbol\":\"\",\"network\":\"DOGE\",\"name\":\"Dogecoin\",\"alias\":\"dogecoin\",\"qty\":\"527.61000000\",\"amount\":\"527.61000000\",\"address\":\"DCcbT48AXJiHWsgfRrMigZDxdyEHh95H48\",\"extra\":\"\",\"tx\":{\"id\":null,\"amount\":null,\"fee\":null,\"ccyfee\":null,\"time\":false,\"timeBlock\":false,\"confirmations\":null}},\"back\":{\"currency\":\"\",\"symbol\":null,\"subSymbol\":null,\"network\":null,\"name\":null,\"alias\":null,\"qty\":\"0.00000000\",\"amount\":\"0.00000000\",\"address\":\"\",\"extra\":\"\",\"tx\":{\"id\":null,\"amount\":null,\"fee\":null,\"ccyfee\":null,\"time\":false,\"timeBlock\":false,\"confirmations\":null}},\"emergency\":{\"status\":[],\"choice\":\"hjfjj\",\"repeat\":\"0\"},\"type\":\"Float\",\"email\":\"\",\"rate\":3471.11842105,\"rateRev\":0.00028809,\"status\":\"3\",\"reg\":1617586255,\"start\":false,\"finish\":false,\"update\":1617586255,\"expiration\":1617586855,\"left\":414,\"step\":\"new\"}}";
        private const string ExchangeStatus4 = "{\"code\":0,\"msg\":\"OK\",\"data\":{\"id\":\"EG598W\",\"from\":{\"currency\":\"LTC\",\"symbol\":\"LTC\",\"subSymbol\":\"\",\"network\":\"LTC\",\"name\":\"Litecoin\",\"alias\":\"litecoin\",\"qty\":\"0.15200000\",\"amount\":\"0.15200000\",\"address\":\"MEp3ibDGRmDsUB8b4dSJ52MV9Y1Bdec532\",\"extra\":\"\",\"tx\":{\"id\":null,\"amount\":null,\"fee\":null,\"ccyfee\":null,\"time\":false,\"timeBlock\":false,\"confirmations\":null}},\"to\":{\"currency\":\"DOGE\",\"symbol\":\"DOGE\",\"subSymbol\":\"\",\"network\":\"DOGE\",\"name\":\"Dogecoin\",\"alias\":\"dogecoin\",\"qty\":\"527.61000000\",\"amount\":\"527.61000000\",\"address\":\"DCcbT48AXJiHWsgfRrMigZDxdyEHh95H48\",\"extra\":\"\",\"tx\":{\"id\":null,\"amount\":null,\"fee\":null,\"ccyfee\":null,\"time\":false,\"timeBlock\":false,\"confirmations\":null}},\"back\":{\"currency\":\"\",\"symbol\":null,\"subSymbol\":null,\"network\":null,\"name\":null,\"alias\":null,\"qty\":\"0.00000000\",\"amount\":\"0.00000000\",\"address\":\"\",\"extra\":\"\",\"tx\":{\"id\":null,\"amount\":null,\"fee\":null,\"ccyfee\":null,\"time\":false,\"timeBlock\":false,\"confirmations\":null}},\"emergency\":{\"status\":[],\"choice\":\"NONE\",\"repeat\":\"0\"},\"type\":\"FIXED\",\"email\":\"\",\"rate\":3471.11842105,\"rateRev\":0.00028809,\"status\":\"4\",\"reg\":1617586255,\"start\":false,\"finish\":false,\"update\":1617586255,\"expiration\":1617586855,\"left\":414,\"step\":\"new\"}}";
        private const string ExchangeStatus5 = "{\"code\":0,\"msg\":\"OK\",\"data\":{\"id\":\"EG598W\",\"from\":{\"currency\":\"LTC\",\"symbol\":\"LTC\",\"subSymbol\":\"\",\"network\":\"LTC\",\"name\":\"Litecoin\",\"alias\":\"litecoin\",\"qty\":\"0.15200000\",\"amount\":\"0.15200000\",\"address\":\"MEp3ibDGRmDsUB8b4dSJ52MV9Y1Bdec532\",\"extra\":\"\",\"tx\":{\"id\":null,\"amount\":null,\"fee\":null,\"ccyfee\":null,\"time\":false,\"timeBlock\":false,\"confirmations\":null}},\"to\":{\"currency\":\"DOGE\",\"symbol\":\"DOGE\",\"subSymbol\":\"\",\"network\":\"DOGE\",\"name\":\"Dogecoin\",\"alias\":\"dogecoin\",\"qty\":\"527.61000000\",\"amount\":\"527.61000000\",\"address\":\"DCcbT48AXJiHWsgfRrMigZDxdyEHh95H48\",\"extra\":\"\",\"tx\":{\"id\":null,\"amount\":null,\"fee\":null,\"ccyfee\":null,\"time\":false,\"timeBlock\":false,\"confirmations\":null}},\"back\":{\"currency\":\"\",\"symbol\":null,\"subSymbol\":null,\"network\":null,\"name\":null,\"alias\":null,\"qty\":\"0.00000000\",\"amount\":\"0.00000000\",\"address\":\"\",\"extra\":\"\",\"tx\":{\"id\":null,\"amount\":null,\"fee\":null,\"ccyfee\":null,\"time\":false,\"timeBlock\":false,\"confirmations\":null}},\"emergency\":{\"status\":[],\"choice\":\"NONE\",\"repeat\":\"0\"},\"type\":\"FLOAT\",\"email\":\"\",\"rate\":3471.11842105,\"rateRev\":0.00028809,\"status\":\"5\",\"reg\":1617586255,\"start\":false,\"finish\":false,\"update\":1617586255,\"expiration\":1617586855,\"left\":414,\"step\":\"new\"}}";
        private const string ExchangeStatus6 = "{\"code\":0,\"msg\":\"OK\",\"data\":{\"id\":\"EG598W\",\"from\":{\"currency\":\"LTC\",\"symbol\":\"LTC\",\"subSymbol\":\"\",\"network\":\"LTC\",\"name\":\"Litecoin\",\"alias\":\"litecoin\",\"qty\":\"0.15200000\",\"amount\":\"0.15200000\",\"address\":\"MEp3ibDGRmDsUB8b4dSJ52MV9Y1Bdec532\",\"extra\":\"\",\"tx\":{\"id\":null,\"amount\":null,\"fee\":null,\"ccyfee\":null,\"time\":false,\"timeBlock\":false,\"confirmations\":null}},\"to\":{\"currency\":\"DOGE\",\"symbol\":\"DOGE\",\"subSymbol\":\"\",\"network\":\"DOGE\",\"name\":\"Dogecoin\",\"alias\":\"dogecoin\",\"qty\":\"527.61000000\",\"amount\":\"527.61000000\",\"address\":\"DCcbT48AXJiHWsgfRrMigZDxdyEHh95H48\",\"extra\":\"\",\"tx\":{\"id\":null,\"amount\":null,\"fee\":null,\"ccyfee\":null,\"time\":false,\"timeBlock\":false,\"confirmations\":null}},\"back\":{\"currency\":\"\",\"symbol\":null,\"subSymbol\":null,\"network\":null,\"name\":null,\"alias\":null,\"qty\":\"0.00000000\",\"amount\":\"0.00000000\",\"address\":\"\",\"extra\":\"\",\"tx\":{\"id\":null,\"amount\":null,\"fee\":null,\"ccyfee\":null,\"time\":false,\"timeBlock\":false,\"confirmations\":null}},\"emergency\":{\"status\":[],\"choice\":\"NONE\",\"repeat\":\"0\"},\"type\":\"fixed\",\"email\":\"\",\"rate\":3471.11842105,\"rateRev\":0.00028809,\"status\":\"6\",\"reg\":1617586255,\"start\":false,\"finish\":false,\"update\":1617586255,\"expiration\":1617586855,\"left\":414,\"step\":\"new\"}}";
        private const string ExchangeStatus7 = "{\"code\":0,\"msg\":\"OK\",\"data\":{\"id\":\"EG598W\",\"from\":{\"currency\":\"LTC\",\"symbol\":\"LTC\",\"subSymbol\":\"\",\"network\":\"LTC\",\"name\":\"Litecoin\",\"alias\":\"litecoin\",\"qty\":\"0.15200000\",\"amount\":\"0.15200000\",\"address\":\"MEp3ibDGRmDsUB8b4dSJ52MV9Y1Bdec532\",\"extra\":\"\",\"tx\":{\"id\":null,\"amount\":null,\"fee\":null,\"ccyfee\":null,\"time\":false,\"timeBlock\":false,\"confirmations\":null}},\"to\":{\"currency\":\"DOGE\",\"symbol\":\"DOGE\",\"subSymbol\":\"\",\"network\":\"DOGE\",\"name\":\"Dogecoin\",\"alias\":\"dogecoin\",\"qty\":\"527.61000000\",\"amount\":\"527.61000000\",\"address\":\"DCcbT48AXJiHWsgfRrMigZDxdyEHh95H48\",\"extra\":\"\",\"tx\":{\"id\":null,\"amount\":null,\"fee\":null,\"ccyfee\":null,\"time\":false,\"timeBlock\":false,\"confirmations\":null}},\"back\":{\"currency\":\"\",\"symbol\":null,\"subSymbol\":null,\"network\":null,\"name\":null,\"alias\":null,\"qty\":\"0.00000000\",\"amount\":\"0.00000000\",\"address\":\"\",\"extra\":\"\",\"tx\":{\"id\":null,\"amount\":null,\"fee\":null,\"ccyfee\":null,\"time\":false,\"timeBlock\":false,\"confirmations\":null}},\"emergency\":{\"status\":[],\"choice\":\"NONE\",\"repeat\":\"0\"},\"type\":\"fixed\",\"email\":\"\",\"rate\":3471.11842105,\"rateRev\":0.00028809,\"status\":\"7\",\"reg\":1617586255,\"start\":false,\"finish\":false,\"update\":1617586255,\"expiration\":1617586855,\"left\":414,\"step\":\"new\"}}";
        private const string ShouldThrow = "{\"code\":0,\"msg\":\"OK\",\"data\":{\"id\":\"EG598W\",\"from\":{\"currency\":\"LTC\",\"symbol\":\"LTC\",\"subSymbol\":\"\",\"network\":\"LTC\",\"name\":\"Litecoin\",\"alias\":\"litecoin\",\"qty\":\"0.15200000\",\"amount\":\"0.15200000\",\"address\":\"MEp3ibDGRmDsUB8b4dSJ52MV9Y1Bdec532\",\"extra\":\"\",\"tx\":{\"id\":null,\"amount\":null,\"fee\":null,\"ccyfee\":null,\"time\":false,\"timeBlock\":false,\"confirmations\":null}},\"to\":{\"currency\":\"DOGE\",\"symbol\":\"DOGE\",\"subSymbol\":\"\",\"network\":\"DOGE\",\"name\":\"Dogecoin\",\"alias\":\"dogecoin\",\"qty\":\"527.61000000\",\"amount\":\"527.61000000\",\"address\":\"DCcbT48AXJiHWsgfRrMigZDxdyEHh95H48\",\"extra\":\"\",\"tx\":{\"id\":null,\"amount\":null,\"fee\":null,\"ccyfee\":null,\"time\":false,\"timeBlock\":false,\"confirmations\":null}},\"back\":{\"currency\":\"\",\"symbol\":null,\"subSymbol\":null,\"network\":null,\"name\":null,\"alias\":null,\"qty\":\"0.00000000\",\"amount\":\"0.00000000\",\"address\":\"\",\"extra\":\"\",\"tx\":{\"id\":null,\"amount\":null,\"fee\":null,\"ccyfee\":null,\"time\":false,\"timeBlock\":false,\"confirmations\":null}},\"emergency\":{\"status\":[],\"choice\":\"NONE\",\"repeat\":\"0\"},\"type\":\"NotGood\",\"email\":\"\",\"rate\":3471.11842105,\"rateRev\":0.00028809,\"status\":\"8\",\"reg\":1617586255,\"start\":false,\"finish\":false,\"update\":1617586255,\"expiration\":1617586855,\"left\":414,\"step\":\"new\"}}";
        #endregion


        [Test]
        [TestCase(ExchangeStatus0, ExchangeStatus.New)]
        [TestCase(ExchangeStatus1, ExchangeStatus.Waiting)]
        [TestCase(ExchangeStatus2, ExchangeStatus.CurrencyExchange)]
        [TestCase(ExchangeStatus3, ExchangeStatus.SendingFunds)]
        [TestCase(ExchangeStatus4, ExchangeStatus.OrderCompleted)]
        [TestCase(ExchangeStatus5, ExchangeStatus.OrderExpired)]
        [TestCase(ExchangeStatus6, ExchangeStatus.NotInUse)]
        [TestCase(ExchangeStatus7, ExchangeStatus.DecisionMustMade)]
        public void TransactionStatusEnumConvertTest(string resposne, ExchangeStatus expect)
        {
            Assert.DoesNotThrow(() => JsonConvert.DeserializeObject<GetOrderResponse>(resposne));
            var res = JsonConvert.DeserializeObject<GetOrderResponse>(resposne);
            Assert.AreEqual(expect, res.Data.Status);
        }

        [Test]
        public void TransactionStatusEnumConvertTestShouldFail()
        {
            Assert.Throws<JsonSerializationException>(() => JsonConvert.DeserializeObject<GetOrderResponse>(ShouldThrow));

        }

        [Test]
        public void TransactionStatusEnumConvertTestShouldFailWithWrongObject()
        {
            Assert.Throws<JsonReaderException>(() => JsonConvert.DeserializeObject<bool>(ShouldThrow));

        }

        [Test]
        [TestCase(ExchangeStatus0, ExchangeType.Fixed)]
        [TestCase(ExchangeStatus1, ExchangeType.Float)]
        [TestCase(ExchangeStatus2, ExchangeType.Fixed)]
        [TestCase(ExchangeStatus3, ExchangeType.Float)]
        [TestCase(ExchangeStatus4, ExchangeType.Fixed)]
        [TestCase(ExchangeStatus5, ExchangeType.Float)]
        public void ExchangeTypeEnumJsonConverterTest(string resposne, ExchangeType expect)
        {
            Assert.DoesNotThrow(() => JsonConvert.DeserializeObject<GetOrderResponse>(resposne));
            var res = JsonConvert.DeserializeObject<GetOrderResponse>(resposne);
            Assert.AreEqual(expect, res.Data.Type);
        }

        [Test]
        public void ExchangeTypeEnumJsonConverterTestShouldFail()
        {
            Assert.Throws<JsonSerializationException>(() => JsonConvert.DeserializeObject<GetOrderResponse>(ShouldThrow));
        }

        [Test]
        [TestCase(ExchangeStatus0, Emergency.REFUND)]
        [TestCase(ExchangeStatus1, Emergency.EXCHANGE)]
        [TestCase(ExchangeStatus2, Emergency.NONE)]
        [TestCase(ExchangeStatus3, Emergency.NONE)]

        public void EmergencyEnumJsonConverterTest(string resposne, Emergency expect)
        {
            Assert.DoesNotThrow(() => JsonConvert.DeserializeObject<GetOrderResponse>(resposne));
            var res = JsonConvert.DeserializeObject<GetOrderResponse>(resposne);
            Assert.AreEqual(expect, res.Data.Emergency.Choice);
        }
    }
}
