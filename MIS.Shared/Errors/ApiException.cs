namespace MIS.Shared.Errors
{
    public class ApiException : ApiResponse
    {
        public ApiException(int statusCode,                            
                            string message = null,
                            string details = null) : base(statusCode, message)
        {
            Details = details;
        }

        public ApiException()
        {

        }

        public string Details { get; set; }
    }
}
