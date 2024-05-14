using Dynamic_Application.Enum;

namespace Dynamic_Application.Abstraction
{
    public sealed class ApiResponse<TResponse> where TResponse : class
    {
        public ResponseCodes Code { get; set; } = ResponseCodes.OK;

        public string? ShortDescription { get; set; } = "Successful";

        public TResponse? Data { get; set; }

    }
}
