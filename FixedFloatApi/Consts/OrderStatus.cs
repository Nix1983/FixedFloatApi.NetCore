namespace FixedFloatApi.Consts
{
    /// <summary>
    /// Status of an order
    /// </summary>
    public static class OrderStatus
    {
        /// <summary>
        /// Code 0
        /// </summary>
        public const string New = "[0] New order, transaction expected";

        /// <summary>
        /// Code 1
        /// </summary>
        public const string Waiting = "[1] The transaction is waiting for the required number of confirmations";

        /// <summary>
        /// Code 2
        /// </summary>
        public const string Exchanged = "[2] Currency exchange (usually lasts a split second)";

        /// <summary>
        /// Code 3
        /// </summary>
        public const string SendingFunds = "[3] Sending funds (usually lasts a split second)";

        /// <summary>
        /// Code 4
        /// </summary>
        public const string Completed = "[4] Order completed";

        /// <summary>
        /// Code 5
        /// </summary>
        public const string Expired = "[5] Order expired";

        /// <summary>
        /// Code 6
        /// </summary>
        public const string NotInUse = "[6] Not currently in use";

        /// <summary>
        /// Code 7
        /// </summary>
        public const string DecisionMustBeMade = "[7] A decision must be made to proceed with the order";
    }
}
