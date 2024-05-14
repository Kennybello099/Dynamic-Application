using Dynamic_Application.Abstraction;
using Microsoft.AspNetCore.Mvc;

namespace Dynamic_Application.ControllerBase
{
    public class ApiControllerBase : Microsoft.AspNetCore.Mvc.ControllerBase
    {
        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult ProcessResponse<TResult>(ApiResponse<TResult> serviceResponse) where TResult : class
        {
            return serviceResponse.Code switch
            {
                Enum.ResponseCodes.OK => Ok(serviceResponse),
                Enum.ResponseCodes.UNAUTHORIZED => Unauthorized(serviceResponse),
                Enum.ResponseCodes.NOT_FOUND => NotFound(serviceResponse),
                Enum.ResponseCodes.BAD_REQUEST => BadRequest(serviceResponse),
                Enum.ResponseCodes.EXCEPTION => StatusCode(StatusCodes.Status500InternalServerError, serviceResponse),
                Enum.ResponseCodes.ERROR => Ok(serviceResponse),
                _=> throw new NotImplementedException()
            };

        }
    }
}
