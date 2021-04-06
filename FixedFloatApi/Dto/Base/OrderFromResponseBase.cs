using Newtonsoft.Json;

namespace FixedFloatApi.Dto.Base
{
    public abstract class OrderFromResponseBase
    {
        /// <summary>
        /// the destination address to which the user is ought to deposit his funds in order for the trade to execute.
        /// </summary>
        [JsonProperty("address")]
        public string Address { get; set; }

        /// <summary>
        /// MEMO or Destination Tag if required
        /// </summary>
        [JsonProperty("extra")]
        public string Extra { get; set; }

        /// <summary>
        /// currency alias for wallets and qr codes
        /// </summary>
        [JsonProperty("alias")]
        public string Alias { get; set; }

        /// <summary>
        /// currency code
        /// </summary>
        [JsonProperty("currency")]
        public string Currency { get; set; }

        /// <summary>
        /// currency name
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// amount of base currency which user sends.
        /// </summary>
        [JsonProperty("qty")]
        public decimal Qty { get; set; }
    }
}
