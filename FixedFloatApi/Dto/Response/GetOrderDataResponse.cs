using FixedFloatApi.Dto.Base;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace FixedFloatApi.Dto.Response
{
    public class GetOrderDataResponse : OrderResponseBase
    {
        /// <summary>
        /// Currency information for exchange
        /// </summary>
        [JsonProperty("from")]
        public GetOrderFromResponse From { get; set; }

        /// <summary>
        /// Currency information for exchange
        /// </summary>
        [JsonProperty("to")]
        public GetOrderToResponse To { get; set; }

        /// <summary>
        /// emergency information (if the user sent later, less, more currency, etc.)
        /// </summary>
        [JsonProperty("emergency")]
        public GetOrderEmergencyResponse Emergency { get; set; }

        /// <summary>
        /// receive time
        /// </summary>
        [JsonProperty("start")]
        public string Start { get; set; }

        /// <summary>
        /// order execution time
        /// </summary>
        [JsonProperty("finish")]
        public string Finish { get; set; }

        /// <summary>
        /// time of the last transaction update
        /// </summary>
        [JsonProperty("update")]
        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime Update { get; set; }

    }
}
