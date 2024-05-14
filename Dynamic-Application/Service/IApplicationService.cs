using Dynamic_Application.Abstraction;
using Dynamic_Application.DTOs;

namespace Dynamic_Application.Service
{
    public interface IApplicationService
    {
        Task<ApiResponse<string>> AddApplication(ApplicationRequestDto model);
        Task<ApiResponse<string>> UpdateApplication(UpdateApplicationDto model);
        Task<ApiResponse<string>> DeleteApplication(long Id);
        Task<ApiResponse<ApplicationResponseDto>> GetApplication(long Id);
        Task<ApiResponse<List<ApplicationResponseDto>>> GetApplications();


    }
}
