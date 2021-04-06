using FixedFloatApi.Helper;

namespace FixedFloatApi.Dto.Requests
{
    public class GetOrderRequest
    {
        /// <summary>
        /// [Required] Get after create an order
        /// </summary>
        public string Id { get; }

        /// <summary>
        /// [Required] Security token of order
        /// </summary>
        public string Token { get; }

        public GetOrderRequest(string id, string token)
        {
            Id = id;
            Token = token;

            Id = CheckRequest.StringValue(Id);
            Token = CheckRequest.StringValue(Token);
        }

    }
}
