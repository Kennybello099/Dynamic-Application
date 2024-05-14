using Dynamic_Application.Abstraction;
using Dynamic_Application.DTOs;
using Dynamic_Application.model;
using System.Collections.Generic;

namespace Dynamic_Application.Repository
{
    public interface IApplicationRepo : IGenericRepository<UserApplication>
    {
        Task<List<ApplicationResponseDto>> GetApplications();
        Task<ApplicationResponseDto> GetApplication(long Id);

    }
}
