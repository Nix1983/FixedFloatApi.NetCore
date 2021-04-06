using FixedFloatApi.Enums;
using FixedFloatApi.Helper;
using System;

namespace FixedFloatApi.Dto.Requests
{
    public class EmergencyRequest
    {
        /// <summary>
        /// [Required] Get after create an order
        /// </summary>
        public string Id { get; }

        /// <summary>
        /// [Required] Security token of order
        /// </summary>
        public string Token { get; }

        /// <summary>
        /// [Required] EXCHANGE or REFUND
        /// </summary>
        public Emergency Choice { get; }

        /// <summary>
        /// [Optional] refund address, required if choice="REFUND"
        /// </summary>
        public string Address { get; }

        public EmergencyRequest(string id, string token, Emergency choice = Emergency.EXCHANGE, string address = "")
        {
            Id = id;
            Token = token;
            Choice = choice;
            Address = address;

            Id = CheckRequest.StringValue(Id);
            Token = CheckRequest.StringValue(Token);
            Address = CheckRequest.StringValue(Address);

            if (Choice == Emergency.REFUND && string.IsNullOrEmpty(Address))
            {
                throw new Exception("Address must be set when Choice is REFUND");
            }

        }   
    }
}
