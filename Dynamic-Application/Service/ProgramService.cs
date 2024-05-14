using Dynamic_Application.Abstraction;
using Dynamic_Application.DTOs;
using Dynamic_Application.model;
using Dynamic_Application.Repository;

namespace Dynamic_Application.Service
{
    public class ProgramService : IProgramService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProgramService(IUnitOfWork unitofWork)
        {
            _unitOfWork = unitofWork;
        }

       
    }
}
