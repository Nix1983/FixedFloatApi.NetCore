namespace FixedFloatApi.Consts
{
    public static class ApiEndPoints
    {
        public const string Root = "https://fixedfloat.com/api/v1/";
        public const string Currencies = Root + "getCurrencies";
        public const string Pair = Root + "getPair";
        public const string Price = Root + "getPrice";
        public const string Order = Root + "getOrder";
        public const string Emergency = Root + "setEmergency";
        public const string CreateOrder = Root + "createOrder";
        public const string XAPIKEY = "X-API-KEY";
        public const string XAPISIGN = "X-API-SIGN";
        public const string ContentType = "application/x-www-form-urlencoded";
    }
}
