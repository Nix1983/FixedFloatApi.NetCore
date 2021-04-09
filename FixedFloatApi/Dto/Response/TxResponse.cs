using Newtonsoft.Json;

namespace FixedFloatApi.Dto.Response
{
    /// <summary>
    /// Order transaction
    /// </summary>
    public class TxResponse
    {
        /// <summary>
        /// Transaction ID in block chain
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Transaction amount
        /// </summary>
        [JsonProperty("amount")]
        public decimal? Amount { get; set; }

        /// <summary>
        /// Transaction confirmations
        /// </summary>
        [JsonProperty("confirmation")]
        public decimal? Confirmation { get; set; }

        /// <summary>
        /// Transaction fee
        /// </summary>
        [JsonProperty("fee")]
        public decimal? Fee { get; set; }

        /// <summary>
        /// Time of transaction creation
        /// </summary>
        [JsonProperty("time")]
        public string Time { get; set; }
    }
}
