using Newtonsoft.Json;

namespace FixedFloatApi.Dto.Response
{
    public class PairDataResponse
    {
        // <summary>
        /// maximum amount of currency available for exchange code
        /// </summary>
        [JsonProperty("max")]
        public decimal Max { get; set; }

        /// <summary>
        /// minimum amount of currency available for exchange
        /// </summary>
        [JsonProperty("min")]
        public decimal Min { get; set; }

        /// <summary>
        /// currency exchange rate
        /// </summary>
        [JsonProperty("rate")]
        public decimal Rate { get; set; }

        /// <summary>
        /// amount
        /// </summary>
        [JsonProperty("amount")]
        public decimal Amount { get; set; }
    }
}
