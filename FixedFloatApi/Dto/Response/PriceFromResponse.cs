using FixedFloatApi.Dto.Base;
using Newtonsoft.Json;

namespace FixedFloatApi.Dto.Response
{
    /// <summary>
    /// Information about the currency you want to exchange
    /// </summary>
    public class PriceFromResponse : PriceResponseBase
    {
        /// <summary>
        /// Amount in USD
        /// </summary>
        [JsonProperty("usd")]
        public decimal Usd { get; set; }
    }
}
