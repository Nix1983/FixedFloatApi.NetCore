using FixedFloatApi.Dto.Base;
using Newtonsoft.Json;

namespace FixedFloatApi.Dto.Response
{
    public class GetOrderToResponse : OrderToResponseBase
    {
        /// <summary>
        /// Block chain infos
        /// </summary>
        [JsonProperty("tx")]
        public TxResponse Tx { get; set; }
    }
}
