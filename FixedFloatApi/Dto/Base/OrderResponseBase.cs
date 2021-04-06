using FixedFloatApi.Converter;
using FixedFloatApi.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace FixedFloatApi.Dto.Base
{
    public abstract class OrderResponseBase
    {
        /// <summary>
        /// order id
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// order type fixed or float
        /// </summary>
        [JsonProperty("type")]
        [JsonConverter(typeof(ExchangeTypeEnumJsonConverter))]
        public ExchangeType Type { get; set; }

        /// <summary>
        /// order step
        /// </summary>
        [JsonProperty("step")]
        public string Step { get; set; }

        /// <summary>
        /// exchange rate
        /// </summary>
        [JsonProperty("rate")]
        public decimal Rate { get; set; }

        /// <summary>
        /// Exchange rate for reverse exchange
        /// </summary>
        [JsonProperty("rateRev")]
        public decimal RateRev { get; set; }

        /// <summary>
        /// order status
        /// </summary>
        [JsonProperty("status")]
        [JsonConverter(typeof(TransactionStatusEnumJsonConverter))]
        public ExchangeStatus Status { get; set; }

        /// <summary>
        /// email address to subscribe for updates
        /// </summary>
        [JsonProperty("email")]
        public string Email { get; set; }

        /// <summary>
        /// Time of order creation
        /// </summary>
        [JsonProperty("reg")]
        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime Reg { get; set; }

        /// <summary>
        /// allowable time to pay for the order
        /// </summary>
        [JsonProperty("expiration")]
        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime Expiration { get; set; }

        /// <summary>
        /// the number of seconds left to pay the order
        /// </summary>
        [JsonProperty("left")]
        public decimal Left { get; set; }
    }
}
