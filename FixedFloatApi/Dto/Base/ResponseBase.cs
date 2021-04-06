using Newtonsoft.Json;

namespace FixedFloatApi.Dto.Base
{
    public abstract class ResponseBase
    {
        /// <summary>
        /// Status code. 0 – OK, else error
        /// </summary>
        [JsonProperty("code")]
        public decimal StatusCode { get; set; }

        /// <summary>
        /// Status message
        /// </summary>
        [JsonProperty("msg")]
        public string Msg { get; set; }
    }
}
