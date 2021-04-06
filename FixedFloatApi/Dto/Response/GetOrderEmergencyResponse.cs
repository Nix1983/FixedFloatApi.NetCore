using FixedFloatApi.Converter;
using FixedFloatApi.Enums;
using Newtonsoft.Json;

namespace FixedFloatApi.Dto.Response
{
    /// <summary>
    /// emergency information (if the user sent later, less, more currency, etc.)
    /// </summary>
    public class GetOrderEmergencyResponse
    {
        /// <summary>
        /// emergency order status. Types of statuses:
        /// LESS, MORE, LIMIT, IMPOSSIBLE
        /// </summary>
        [JsonProperty("status")]
        public object [] Status { get; set; }

        /// <summary>
        /// choice of the option to continue the order in case of an emergency
        /// EXCHANGE or REFUND
        /// </summary>
        [JsonProperty("choice")]
        [JsonConverter(typeof(EmergencyEnumJsonConverter))]
        public Emergency Choice { get; set; }

        /// <summary>
        /// If the value is 1, then several transactions have been sent to this address. 
        /// This could mean a transaction for Replace By Fee or a resend. 
        /// You need to contact technical support to resolve the issue.
        /// </summary>
        [JsonProperty("repeat")]
        public string Repeat { get; set; }

        /// <summary>
        /// The amount of currency that occurs when the user has sent more or less than the currency specified in the order.
        /// </summary>
        [JsonProperty("amount")]
        public decimal Amount { get; set; }

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
        /// emergency order transaction
        /// </summary>
        [JsonProperty("tx")]
        public TxResponse Tx { get; set; }

    }
}
