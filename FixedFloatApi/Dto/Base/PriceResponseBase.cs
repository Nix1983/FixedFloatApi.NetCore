using Newtonsoft.Json;

namespace FixedFloatApi.Dto.Base
{
    public abstract class PriceResponseBase
    {
        /// <summary>
        /// the amount you want to exchange
        /// </summary>
        [JsonProperty("amount")]
        public decimal Amount { get; set; }

        /// <summary>
        /// currency code
        /// </summary>
        [JsonProperty("currency")]
        public string Currency { get; set; }

        /// <summary>
        /// maximum possible amount for exchange
        /// </summary>
        [JsonProperty("max")]
        public decimal Max { get; set; }

        /// <summary>
        /// minimal possible amount for exchange
        /// </summary>
        [JsonProperty("min")]
        public decimal Min { get; set; }

        /// <summary>
        /// the number of digits after the decimal point, which determines the minimum unit of this currency
        /// </summary>
        [JsonProperty("precision")]
        public decimal Precision { get; set; }

        /// <summary>
        /// currency exchange rate
        /// </summary>
        [JsonProperty("rate")]
        public decimal Rate { get; set; }

    }
}
