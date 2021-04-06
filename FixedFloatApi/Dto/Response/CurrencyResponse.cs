using FixedFloatApi.Dto.Base;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace FixedFloatApi.Dto.Response
{
    public class CurrencyResponse : ResponseBase
    {
        [JsonProperty("data")]
        public List<CurrenciesResponse> Currencies { get; set; }
    }
}
