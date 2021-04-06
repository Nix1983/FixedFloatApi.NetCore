using FixedFloatApi.Converter;
using FixedFloatApi.Dto.Base;
using Newtonsoft.Json;

namespace FixedFloatApi.Dto.Response
{
    public class EmergencyResponse : ResponseBase
    {
        /// <summary>
        ///  True if successfully set
        /// </summary>
        [JsonProperty("data")]
        [JsonConverter(typeof(BooleanJsonConverter))]
        public bool IsSuccessfullySet { get; set; }
    }
}
