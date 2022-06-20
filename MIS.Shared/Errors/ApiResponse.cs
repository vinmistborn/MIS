using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MIS.Shared.Errors
{
    public class ApiResponse
    {
        public ApiResponse(int statusCode,                           
                           string message = null)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessageForStatusCode(statusCode);
        }

        public int StatusCode { get; set; }
        public string Message { get; set; }

        public ApiResponse()
        {

        }

        private string GetDefaultMessageForStatusCode(int statusCode)
        {
            return statusCode switch
            {
                400 => "Bad Request",
                401 => "Not Authorized",
                404 => "Not Found",
                500 => "Internal server error",
                _ => null
            };
        }

    }
}
