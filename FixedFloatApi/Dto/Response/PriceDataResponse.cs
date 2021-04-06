using Newtonsoft.Json;

namespace FixedFloatApi.Dto.Response
{
    public class PriceDataResponse
    {
        /// <summary>
        /// Information about the currency you want to exchange
        /// </summary>
        [JsonProperty("from")]
        public PriceFromResponse From { get; set; }

        /// <summary>
        /// Information about the currency to which you want to exchange
        /// </summary>
        [JsonProperty("to")]
        public PriceToResponse To { get; set; }
    }
}
