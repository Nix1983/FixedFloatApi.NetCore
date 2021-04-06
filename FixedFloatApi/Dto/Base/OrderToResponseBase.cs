using Newtonsoft.Json;

namespace FixedFloatApi.Dto.Base
{
    public abstract class OrderToResponseBase
    {
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
        /// currency alias for wallets and qr codes
        /// </summary>
        [JsonProperty("alias")]
        public string Alias { get; set; }

        /// <summary>
        /// a destination address to which the funds will be dispatched upon the successful completion of the Order. 
        /// If MEMO or Destination Tag was specified, then it will be added to this field separated by a colon
        /// </summary>
        [JsonProperty("address")]
        public string Address { get; set; }

        /// <summary>
        /// amount of currency that is sent to the user
        /// </summary>
        [JsonProperty("qty")]
        public decimal Qty { get; set; }
    }
}
