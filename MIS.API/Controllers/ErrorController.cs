using Microsoft.AspNetCore.Mvc;
using MIS.Shared.Errors;

namespace MIS.API.Controllers
{
    [Route("errors/{statusCode}")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ErrorController : BaseController
    {
        public IActionResult Error(int statusCode)
        {
            return new ObjectResult (new ApiResponse(statusCode) );
        }
    }
}
