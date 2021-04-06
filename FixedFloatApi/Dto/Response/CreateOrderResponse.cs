using FixedFloatApi.Dto.Base;
using Newtonsoft.Json;

namespace FixedFloatApi.Dto.Response
{
    public class CreateOrderResponse : ResponseBase
    {
        /// <summary>
        /// Contains all information of the order
        /// </summary>
        [JsonProperty("data")]
        public CreateOrderDataResponse Data { get; set; }

    }
}
