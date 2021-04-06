namespace FixedFloatApi.Helper
{
    public static class CheckRequest
    {
        public static string StringValue(string val)
        {
            if (val == null) val = string.Empty;

            return val;
        }

        public static decimal NumberValue(decimal val)
        {
            if (val <= 0) val = (decimal)0.1;

            return val;
        }
    }
}
