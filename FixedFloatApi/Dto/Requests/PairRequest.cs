using FixedFloatApi.Helper;

namespace FixedFloatApi.Dto.Requests
{
    public class PairRequest
    {
        /// <summary>
        /// [Required] From currency
        /// </summary>
        public string FromCurrency { get; }

        /// <summary>
        /// [Required] To currency
        /// </summary>
        public string ToCurrency { get; }

        /// <summary>
        /// [Optional] Amount
        /// </summary>
        public decimal FromQty { get; }

        public PairRequest(string fromCurrency, string toCurrency, decimal fromQty = 0)
        {
            FromCurrency = fromCurrency;
            ToCurrency = toCurrency;
            FromQty = fromQty;

            FromCurrency = CheckRequest.StringValue(FromCurrency);
            ToCurrency = CheckRequest.StringValue(ToCurrency);

        }

        public PairRequest(PriceRequest price)
        {
            FromCurrency = price.FromCurrency;
            ToCurrency = price.ToCurrency;
            FromQty = price.FromQty;

            FromCurrency = CheckRequest.StringValue(FromCurrency);
            ToCurrency = CheckRequest.StringValue(ToCurrency);

        }

    }
}
