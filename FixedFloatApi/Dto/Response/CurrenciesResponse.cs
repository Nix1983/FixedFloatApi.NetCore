using FixedFloatApi.Converter;
using Newtonsoft.Json;

namespace FixedFloatApi.Dto.Response
{
    public class CurrenciesResponse
    {
        /// <summary>
        /// Currency code
        /// </summary>
        [JsonProperty("currency")]
        public string CurrencyCode { get; set; }

        /// <summary>
        /// Currency symbol
        /// </summary>
        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        /// <summary>
        /// Currency name
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Currency alias for wallets and qr codes
        /// </summary>
        [JsonProperty("alias")]
        public string Alias { get; set; }

        /// <summary>
        /// Currency type
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// Currency color
        /// </summary>
        [JsonProperty("color")]
        public string Color { get; set; }

        /// <summary>
        /// The number of digits after the decimal point, 
        /// which determines the minimum unit of this currency
        /// </summary>
        [JsonProperty("precision")]
        public decimal Precision { get; set; }

        /// <summary>
        /// Currency available or unavailable for sending in exchange
        /// </summary>
        [JsonProperty("send")]
        [JsonConverter(typeof(BooleanJsonConverter))]
        public bool Send { get; set; }

        /// <summary>
        /// Currency available or unavailable for receiving in exchange
        /// </summary>
        [JsonProperty("recv")]
        [JsonConverter(typeof(BooleanJsonConverter))]
        public bool Recv { get; set; }
    }
      
}
