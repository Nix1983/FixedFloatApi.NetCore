using FixedFloatApi.Enums;
using FixedFloatApi.Helper;

namespace FixedFloatApi.Dto.Requests
{
    public class PriceRequest
    {
        /// <summary>
        /// [Required] From Currency
        /// </summary>
        public string FromCurrency { get; }

        /// <summary>
        /// [Required] To Currency
        /// </summary>
        public string ToCurrency { get; }

        /// <summary>
        /// [Required] Amount you want to exchange
        /// must greater then 0. 
        /// If FromQty <= 0 it will set to 0.1
        /// </summary>
        public decimal FromQty { get; }

        /// <summary>
        /// [Optional] Amount
        /// </summary>
        public decimal ToQty { get; }

        /// <summary>
        /// [Required] Type of exchange fixed or float
        /// </summary>
        public ExchangeType Type { get; }

        public PriceRequest(string fromCurrency, string toCurrency, decimal fromQty, ExchangeType type = ExchangeType.Float, decimal toQty = 0)
        {
            FromCurrency = fromCurrency;
            ToCurrency = toCurrency;
            FromQty = fromQty;
            Type = type;
            ToQty = toQty;

            FromCurrency = CheckRequest.StringValue(FromCurrency);
            FromQty = CheckRequest.NumberValue(FromQty);
            ToCurrency = CheckRequest.StringValue(ToCurrency);
        }

        public PriceRequest(PairRequest pair, ExchangeType type = ExchangeType.Float)
        {
            FromCurrency = pair.FromCurrency;
            ToCurrency = pair.ToCurrency;
            FromQty = pair.FromQty;
            Type = type;
            ToQty = 0;

            FromCurrency = CheckRequest.StringValue(FromCurrency);
            FromQty = CheckRequest.NumberValue(FromQty);
            ToCurrency = CheckRequest.StringValue(ToCurrency);

        }

      
    }
}
