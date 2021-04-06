using FixedFloatApi.Dto;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTests
{ 
    [TestFixture]
    public class AuthenticationTests
    {
        [Test]
        public void SignatureTest()
        {
            var auth = new Authentication("test", "qVeyDheFpFavNy8kSy1vJc9SG8FZnFeWnJDf9ACx");
            Assert.AreEqual("a25b61d23c4811ead7738c2124a6d06ebb4b8a4d695da46a2ad8965553d09333", auth.GetSignature("from=ETH&to=BTC"));
        }
    }
}
