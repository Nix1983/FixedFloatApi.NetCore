using FixedFloatApi.Dto.Base;
using Newtonsoft.Json;

namespace FixedFloatApi.Dto.Response
{
    public class PairResponse : ResponseBase
    {
        [JsonProperty("data")]
        public PairDataResponse Data { get; set; }
    }
}
