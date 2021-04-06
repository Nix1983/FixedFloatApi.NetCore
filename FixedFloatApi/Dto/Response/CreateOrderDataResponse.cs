using FixedFloatApi.Dto.Base;
using Newtonsoft.Json;

namespace FixedFloatApi.Dto.Response
{
    public class CreateOrderDataResponse : OrderResponseBase
    {
        
        /// <summary>
        /// security token with which you can receive and manage order information.
        /// </summary>
        [JsonProperty("token")]
        public string Token { get; set; }

        /// <summary>
        /// currency information for exchange
        /// </summary>
        [JsonProperty("from")]
        public CreateOrderFromResponse From { get; set; }

        /// <summary>
        /// cInformation for the currency to be exchanged
        /// </summary>
        [JsonProperty("to")]
        public CreateOrderToResponse To { get; set; }

      
    }
}
