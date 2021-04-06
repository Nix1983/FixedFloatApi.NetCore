using FixedFloatApi.Enums;
using FixedFloatApi.Helper;

namespace FixedFloatApi.Dto.Requests
{
    public class CreateOrderRequest
    {
        /// <summary>
        /// [Required] currency code which user sends
        /// </summary>
        public string FromCurrency { get; }

        /// <summary>
        /// [Required] currency code that is sent to the user
        /// </summary>
        public string ToCurrency { get; }

        /// <summary>
        /// [Required] amount of base currency which user sends
        /// </summary>
        public decimal FromQty { get; }

        /// <summary>
        /// [Optional] amount of currency that is sent to the user
        /// </summary>
        public decimal ToQty { get; }

        /// <summary>
        /// [Required] 	
        /// A destination address to which the funds will be dispatched upon the successful completion of the Order
        /// </summary>
        public string ToAddress { get; }

        /// <summary>
        /// [Optional] 
        /// if you need to specify a Memo or Destination Tag when sending, you should specify it here
        /// Not supported until now
        /// </summary>
        public string Extra { get; }

        /// <summary>
        /// [Required] Type of exchange fixed or float
        /// </summary>
        public ExchangeType Type { get; }

        public CreateOrderRequest(string fromCurrency, string toCurrency, decimal fromQty, string toAddress, ExchangeType type = ExchangeType.Float, string extra = "", decimal toQty = 0)
        {
            FromCurrency = fromCurrency;
            ToCurrency = toCurrency;
            FromQty = fromQty;
            ToAddress = toAddress;
            Type = type;
            Extra = extra;
            ToQty = toQty;

            FromCurrency = CheckRequest.StringValue(FromCurrency);
            ToCurrency = CheckRequest.StringValue(ToCurrency);
            ToAddress = CheckRequest.StringValue(ToAddress);
            Extra = CheckRequest.StringValue(Extra);
        }

        public CreateOrderRequest(PriceRequest price, string toAddress, ExchangeType type = ExchangeType.Float)
        {

            FromCurrency = price.FromCurrency;
            ToCurrency = price.ToCurrency;
            FromQty = price.FromQty;
            ToAddress = toAddress;
            Type = type;

            FromCurrency = CheckRequest.StringValue(FromCurrency);
            ToCurrency = CheckRequest.StringValue(ToCurrency);
            ToAddress = CheckRequest.StringValue(ToAddress);
            Extra = CheckRequest.StringValue(Extra);
        }

    }
}
