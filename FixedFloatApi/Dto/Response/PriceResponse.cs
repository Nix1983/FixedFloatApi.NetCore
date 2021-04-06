using FixedFloatApi.Dto.Base;
using Newtonsoft.Json;

namespace FixedFloatApi.Dto.Response
{
    public class PriceResponse : ResponseBase
    {
        [JsonProperty("data")]
        public PriceDataResponse Data { get; set; }
    }
}
