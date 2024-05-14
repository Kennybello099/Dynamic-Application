using Dynamic_Application.Abstraction;
using Dynamic_Application.ControllerBase;
using Dynamic_Application.DTOs;
using Dynamic_Application.Service;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace Application.Controllers 
{
    [Route("apiv1/[controller]")]
    [ApiController]
    public class ApplicationController(IApplicationService informationService) : ApiControllerBase
    {
        private readonly IApplicationService _informationService = informationService;

        [HttpPost]
        [Route("Personal-Information")]
        [ProducesResponseType(typeof(ApiResponse<string>), StatusCodes.Status200OK)]
        public async Task<IActionResult> AddApplication([FromBody] ApplicationRequestDto model)
        {
            var result = await _informationService.AddApplication(model);
            return ProcessResponse(result);
        }
        [HttpPut]
        [Route("Personal-Information")]
        [ProducesResponseType(typeof(ApiResponse<string>), StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateApplication([FromBody] UpdateApplicationDto model)
        {
            var result = await _informationService.UpdateApplication(model);
            return ProcessResponse(result);
        }
        [HttpGet]
        [Route("Personal-Information")]
        [ProducesResponseType(typeof(ApiResponse<ApplicationResponseDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetApplication(long Id)
        {
            var result = await _informationService.GetApplication(Id);
            return ProcessResponse(result);
        }
        [HttpGet]
        [Route("Personal-Informations")]
        [ProducesResponseType(typeof(ApiResponse<ApplicationResponseDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetApplications()
        {
            var result = await _informationService.GetApplications();
            return ProcessResponse(result);
        }
        [HttpDelete]
        [Route("Personal-Information")]
        [ProducesResponseType(typeof(ApiResponse<string>), StatusCodes.Status200OK)]
        public async Task<IActionResult> DeleteApplication(long Id)
        {
            var result = await _informationService.DeleteApplication(Id);
            return ProcessResponse(result);
        }
    }
}
