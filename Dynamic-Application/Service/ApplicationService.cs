using Dynamic_Application.Abstraction;
using Dynamic_Application.DTOs;
using Dynamic_Application.Enum;
using Dynamic_Application.model;
using Dynamic_Application.Repository;
using Dynamic_Application.Utility;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Eventing.Reader;

namespace Dynamic_Application.Service
{
    public class ApplicationService : IApplicationService
    {
        private readonly IUnitOfWork _unitofWork;

        public ApplicationService(IUnitOfWork unitofWork)
        {
            _unitofWork = unitofWork;
        }

        public async Task<ApiResponse<string>> AddApplication(ApplicationRequestDto model)
        {
            try
            {
                model.FirstName = model.FirstName.Trim();
                model.LastName = model.LastName.Trim();
                model.PhoneNumber = model.PhoneNumber.Trim();
                model.Email = model.Email.Trim();
                model.Nationality = model.Nationality.Trim();
                model.DateOfBirth = model.DateOfBirth.Trim();
                model.ProgramTitle = model.ProgramTitle.Trim();
                model.ProgramDescription = model.ProgramDescription.Trim();
                model.IDNumber = model.IDNumber;
               

                if(!Validation.IsValidPhoneNumber(model.PhoneNumber))
                {
                    return new ApiResponse<string> { Code = ResponseCodes.BAD_REQUEST, ShortDescription = "Invalid phone number." };
                }
                if (!Validation.IsValidEmail(model.Email))
                {
                    return new ApiResponse<string> { Code = ResponseCodes.BAD_REQUEST, ShortDescription = "Invalid Email Address." };
                }

                UserApplication result = new UserApplication()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    PhoneNumber = model.PhoneNumber,
                    Email = model.Email,
                    Nationality = model.Nationality,
                    DateOfBirth = model.DateOfBirth,
                    Gender = model.Gender.ToString(),
                    CreatedAt = DateTime.UtcNow,                 
                    Residence = model.Residence,

                };              

                Programs program = new Programs()
                {
                    ProgramTitle = model.ProgramTitle,
                    ProgramDescription = model.ProgramDescription,
                    Email = result.Email
                };


                await _unitofWork.ApplicationRepo.InsertAsync(result);
                await _unitofWork.ProgramRepo.InsertAsync(program);
                await _unitofWork.questionAndAnswerRepo.AddQuestionAndAnswer(model);

                await _unitofWork.SaveAsync();


                return new ApiResponse<string> { Code = ResponseCodes.OK, ShortDescription = "Information has been saved successfully." };

            }
            catch (Exception)
            {

                throw new Exception("Unable to save personal Information.");
            }
        }

        public async Task<ApiResponse<string>> DeleteApplication(long Id)
        {
            var getinfo = await _unitofWork.ApplicationRepo.GetAll(x => x.Id == Id)
                .Include(x=>x.Program)
                .Include(x=>x.QuestionAndAnswers)
                .FirstOrDefaultAsync();

            if (getinfo is null)
            {
                return new ApiResponse<string> { Code = ResponseCodes.NOT_FOUND, ShortDescription = "User's information does not exist." };
            }

            _unitofWork.ApplicationRepo.Delete(getinfo);
            await _unitofWork.SaveAsync();

            return new ApiResponse<string> { Code = ResponseCodes.NOT_FOUND, ShortDescription = "User's information has been deleted successfully." };
        }
    

        public async Task<ApiResponse<ApplicationResponseDto>> GetApplication(long Id)
        {

            var getinfo = await _unitofWork.ApplicationRepo.GetApplication(Id);

            if (getinfo is null)
            {
                return new ApiResponse<ApplicationResponseDto> { Code = ResponseCodes.NOT_FOUND, ShortDescription = "User's information does not exist." };
            }

            return new ApiResponse<ApplicationResponseDto> { Data = getinfo, Code = ResponseCodes.OK, ShortDescription = "User's information has been deleted successfully." };
        }

        public async Task<ApiResponse<List<ApplicationResponseDto>>> GetApplications()
        {
            var result = await _unitofWork.ApplicationRepo.GetApplications();
            return new ApiResponse<List<ApplicationResponseDto>> { Data = result, Code = ResponseCodes.OK };
        }

        public async Task<ApiResponse<string>> UpdateApplication(UpdateApplicationDto model)
        {
            try
            {
                var getinfo = await _unitofWork.ApplicationRepo.GetAsync(x => x.Id == model.UserId);

                if (getinfo is null)
                {
                    return new ApiResponse<string> { Code = ResponseCodes.NOT_FOUND, ShortDescription = "User's information does not exist." };
                }

                if (!Validation.IsValidPhoneNumber(model.PhoneNumber))
                {
                    return new ApiResponse<string> { Code = ResponseCodes.BAD_REQUEST, ShortDescription = "Invalid phone number." };
                }
                if (!Validation.IsValidEmail(model.Email))
                {
                    return new ApiResponse<string> { Code = ResponseCodes.BAD_REQUEST, ShortDescription = "Invalid Email Address." };
                }
                var updatePersonaInfo = await _unitofWork.ApplicationRepo.GetAll(x => x.Id == getinfo.Id)
                    .Include(y => y.Program).FirstOrDefaultAsync();


                //Update Personal Information
                updatePersonaInfo.FirstName = model.FirstName.Trim();
                updatePersonaInfo.LastName = model.LastName.Trim();
                updatePersonaInfo.PhoneNumber = model.PhoneNumber.Trim();
                updatePersonaInfo.Email = model.Email.Trim();
                updatePersonaInfo.Nationality = model.Nationality.Trim();
                updatePersonaInfo.DateOfBirth = model.DateOfBirth.Trim();
                updatePersonaInfo.Gender = model.Gender.ToString();
                updatePersonaInfo.Program.ProgramTitle = model.ProgramTitle.Trim();
                updatePersonaInfo.Program.ProgramDescription = model.ProgramDescription.Trim();              
                updatePersonaInfo.ModifiedAt = DateTime.UtcNow;
                updatePersonaInfo.IDNumber = model.IDNumber;

                _unitofWork.ApplicationRepo.Update(getinfo);
                await _unitofWork.SaveAsync();


                //Update Program
                var getProgramInfo = await _unitofWork.ProgramRepo.GetAsync(x => x.Email == updatePersonaInfo.Email);
                getProgramInfo.ProgramTitle = model.ProgramTitle;
                getProgramInfo.ProgramDescription = model.ProgramDescription;

                 _unitofWork.ProgramRepo.Update(getProgramInfo);


                //update question and answer
                await _unitofWork.questionAndAnswerRepo.UpdateQuestionAndAnswer(model);
                await _unitofWork.SaveAsync();

                return new ApiResponse<string> { Code = ResponseCodes.OK, ShortDescription = "User's application has been updated successfully." };


            }
            catch (Exception)
            {
                throw new Exception("Unable to update Application.");

            }

        }
    }
}
