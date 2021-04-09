using FixedFloatApi.Consts;
using FixedFloatApi.Dto;
using FixedFloatApi.Dto.Requests;
using FixedFloatApi.Dto.Response;
using Newtonsoft.Json;
using RestSharp;
using System.Globalization;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace FixedFloatApi
{
    /// <summary>
    /// Use Instance to get a object [Singleton] 
    /// </summary>
    public class FixedFloatClient
    {
        #region //---- member ----

        private static Authentication _auth;

        private static FixedFloatClient _client;

        #endregion

        #region //---- public function ----

        /// <summary>
        /// Get Instance of a client [Singleton]
        /// </summary>
        /// <param name="auth"></param>
        /// <returns></returns>
        public static FixedFloatClient Instance(Authentication auth)
        {
            if (_client == null)
            {
                _client = new FixedFloatClient(auth);
            }
            else
            {
                _auth = auth;
            }

            return _client;
        }

        /// <summary>
        /// Getting a list of all currencies that are available on FixedFloat.com
        /// </summary>
        /// <returns></returns>
        public CurrencyResponse GetCurrencies()
        {
            var res = MakeRequest(ApiEndPoints.Currencies, string.Empty, Method.POST);
            return JsonConvert.DeserializeObject<CurrencyResponse>(res);
        }

        /// <summary>
        /// Getting a list of all currencies that are available on FixedFloat.com
        /// </summary>
        /// <returns></returns>
        public async Task<CurrencyResponse> GetCurrenciesAsync()
        {
            var res = await MakeRequestAsync(ApiEndPoints.Currencies, string.Empty, Method.POST);
            return JsonConvert.DeserializeObject<CurrencyResponse>(res);
        }

        /// <summary>
        /// Information on currency pairs: rates, amount of currency available for exchange.
        /// </summary>
        /// <param name="pair"></param>
        /// <returns></returns>
        public PairResponse GetPair(PairRequest pair)
        {
            var data = GetPairRequestString(pair);
            var res = MakeRequest(ApiEndPoints.Pair, data, Method.POST);
            if (res.Contains("false") && res.Contains(Messages.OK))
            {
                return new PairResponse() { Data = null, Msg = Messages.PairIsNotAvailable, StatusCode = 0 };
            }
            return JsonConvert.DeserializeObject<PairResponse>(res);
        }

        /// <summary>
        /// Information on currency pairs: rates, amount of currency available for exchange.
        /// </summary>
        /// <param name="pair"></param>
        /// <returns></returns>
        public async Task<PairResponse> GetPairAsync(PairRequest pair)
        {
            var data = GetPairRequestString(pair);
            var res = await MakeRequestAsync(ApiEndPoints.Pair, data, Method.POST);
            if (res.Contains("false") && res.Contains(Messages.OK))
            {
                return new PairResponse() { Data = null, Msg = Messages.PairIsNotAvailable, StatusCode = 0 };
            }
            return JsonConvert.DeserializeObject<PairResponse>(res);
        }

        /// <summary>
        /// Information about a currency pair with a set amount of funds.
        /// </summary>
        /// <param name="price"></param>
        /// <returns></returns>
        public PriceResponse GetPrice(PriceRequest price)
        {
            var data = GetPriceRequestString(price);
            var res = MakeRequest(ApiEndPoints.Price, data, Method.POST);
            return JsonConvert.DeserializeObject<PriceResponse>(res);
        }

        /// <summary>
        /// Information about a currency pair with a set amount of funds.
        /// </summary>
        /// <param name="price"></param>
        /// <returns></returns>
        public async Task<PriceResponse> GetPriceAsync(PriceRequest price)
        {
            var data = GetPriceRequestString(price);
            var res = await MakeRequestAsync(ApiEndPoints.Price, data, Method.POST);
            return JsonConvert.DeserializeObject<PriceResponse>(res);
        }

        /// <summary>
        /// Creating exchange orders.
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public CreateOrderResponse CreateOrder(CreateOrderRequest order)
        {
            var data = GetCreateOrderRequestString(order);
            var res = MakeRequest(ApiEndPoints.CreateOrder, data, Method.POST);
            return JsonConvert.DeserializeObject<CreateOrderResponse>(res);
        }

        /// <summary>
        /// Creating exchange orders.
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public async Task<CreateOrderResponse> CreateOrderAsync(CreateOrderRequest order)
        {
            var data = GetCreateOrderRequestString(order);
            var res = await MakeRequestAsync(ApiEndPoints.CreateOrder, data, Method.POST);
            return JsonConvert.DeserializeObject<CreateOrderResponse>(res);
        }

        /// <summary>
        /// Emergency Action Choice
        /// </summary>
        /// <param name="emergency"></param>
        /// <returns></returns>
        public EmergencyResponse SetEmergency(EmergencyRequest emergency)
        {
            var data = GetEmergencyRequestString(emergency);
            var res = MakeRequest(ApiEndPoints.Emergency, data, Method.POST);
            if (res.Contains("false") && res.Contains(Messages.OK))
            {
                return new EmergencyResponse() { IsSuccessfullySet = false, Msg = Messages.PairIsNotAvailable, StatusCode = 0 };
            }
            return JsonConvert.DeserializeObject<EmergencyResponse>(res);

        }

        /// <summary>
        /// Emergency Action Choice
        /// </summary>
        /// <param name="emergency"></param>
        /// <returns></returns>
        public async Task<EmergencyResponse> SetEmergencyAsync(EmergencyRequest emergency)
        {
            var data = GetEmergencyRequestString(emergency);
            var res = await MakeRequestAsync(ApiEndPoints.Emergency, data, Method.POST);
            if (res.Contains("false") && res.Contains(Messages.OK))
            {
                return new EmergencyResponse() { IsSuccessfullySet = false, Msg = Messages.PairIsNotAvailable, StatusCode = 0 };
            }
            return JsonConvert.DeserializeObject<EmergencyResponse>(res);

        }

        /// <summary>
        /// Receiving information about the order.
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public GetOrderResponse GetOrder(GetOrderRequest order)
        {
            var data = GetOrderRequestString(order);
            var res = MakeRequest(ApiEndPoints.Order, data, Method.POST);
            return JsonConvert.DeserializeObject<GetOrderResponse>(res);
        }

        /// <summary>
        /// Receiving information about the order.
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public async Task<GetOrderResponse> GetOrderAsync(GetOrderRequest order)
        {
            var data = GetOrderRequestString(order);
            var res = await MakeRequestAsync(ApiEndPoints.Order, data, Method.POST);
            return JsonConvert.DeserializeObject<GetOrderResponse>(res);
        }

        #endregion

        #region //---- private functions ----

        private FixedFloatClient(Authentication auth)
        {
            _auth = auth;
        }

        private string MakeRequest(string url, string data, Method method)
        {
            var httpRequest = GetHttpWebRequest(url, data, method);

            using (var streamWriter = new StreamWriter(httpRequest.GetRequestStream()))
            {
                streamWriter.Write(data);
            }
            string res;
            var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                res = streamReader.ReadToEnd();

            }
            return res;
        }

        private async Task<string> MakeRequestAsync(string url, string data, Method method)
        {
            var httpRequest = GetHttpWebRequest(url, data, method);

            using (var streamWriter = new StreamWriter(httpRequest.GetRequestStream()))
            {
                streamWriter.Write(data);
            }
            string res;
            using (WebResponse httpResponse = await httpRequest.GetResponseAsync())
            {
                using var streamReader = new StreamReader(httpResponse.GetResponseStream());
                res = streamReader.ReadToEnd();
            }
            return res;
        }

        private string GetPairRequestString(PairRequest pair)
        {
            return $"from={pair.FromCurrency.ToUpper()}&to={pair.ToCurrency.ToUpper()}&amount={pair.FromQty.ToString(CultureInfo.InvariantCulture)}";
        }

        private string GetPriceRequestString(PriceRequest price)
        {
            return $"fromCurrency={price.FromCurrency.ToUpper()}&fromQty={price.FromQty.ToString(CultureInfo.InvariantCulture)}&toCurrency={price.ToCurrency.ToUpper()}&toQty={price.ToQty.ToString(CultureInfo.InvariantCulture)}&type={price.Type.ToString().ToLower()}";
        }

        private string GetCreateOrderRequestString(CreateOrderRequest order)
        {
            return $"fromCurrency={order.FromCurrency.ToUpper()}&toCurrency={order.ToCurrency.ToUpper()}&fromQty={order.FromQty.ToString(CultureInfo.InvariantCulture)}&toQty={order.ToQty.ToString(CultureInfo.InvariantCulture)}&toAddress={order.ToAddress}&type={order.Type.ToString().ToLower()}";
        }

        private string GetEmergencyRequestString(EmergencyRequest emergency)
        {
            return $"id={emergency.Id}&token={emergency.Token}&choice={emergency.Choice.ToString().ToUpper()}&address={emergency.Address}";
        }

        private string GetOrderRequestString(GetOrderRequest order)
        {
            return $"id={order.Id}&token={order.Token}";
        }

        private HttpWebRequest GetHttpWebRequest(string url, string data, Method method)
        {
            var httpRequest = (HttpWebRequest)WebRequest.Create(url);
            httpRequest.Method = method.ToString();
            httpRequest.Headers[ApiEndPoints.XAPIKEY] = _auth.ApiKey;
            httpRequest.Headers[ApiEndPoints.XAPISIGN] = _auth.GetSignature(data);
            httpRequest.ContentType = ApiEndPoints.ContentType;
            return httpRequest;
        }


        #endregion
    }
}
