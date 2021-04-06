using FixedFloatApi.Dto.Base;
using Newtonsoft.Json;

namespace FixedFloatApi.Dto.Response
{
    public class GetOrderResponse : ResponseBase
    {
        /// <summary>
        /// Data of from an active order
        /// </summary>
        [JsonProperty("data")]
        public GetOrderDataResponse Data { get; set; }
    }
}
