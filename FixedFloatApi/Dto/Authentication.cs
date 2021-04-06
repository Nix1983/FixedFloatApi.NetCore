using System;
using System.Security.Cryptography;
using System.Text;

namespace FixedFloatApi.Dto
{
    public class Authentication
    {
        public string ApiKey { get; }

        private readonly string _secretKey;

        public Authentication(string apiKey, string secret)
        {
            ApiKey = apiKey;
            _secretKey = secret;
        }

        public string GetSignature(string data)
        {
            if(data == null) data = string.Empty;
     
            var encoding = new ASCIIEncoding();
            var secretBytes = encoding.GetBytes(_secretKey);
            var messageBytes = encoding.GetBytes(data);
            var cryptographer = new HMACSHA256(secretBytes);
            var bytes = cryptographer.ComputeHash(messageBytes);
            return BitConverter.ToString(bytes).Replace("-", "").ToLower();
        }
    }
}
