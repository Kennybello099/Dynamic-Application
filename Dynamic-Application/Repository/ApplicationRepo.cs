using Dynamic_Application.Abstraction;
using Dynamic_Application.AppContext;
using Dynamic_Application.DTOs;
using Dynamic_Application.model;
using Microsoft.EntityFrameworkCore;
using System.Net.NetworkInformation;

namespace Dynamic_Application.Repository
{
    public class ApplicationRepo(ApplicationData _context) : GenericRepository<UserApplication>(_context), IApplicationRepo
    {
        public Task<ApplicationResponseDto> GetApplication(long Id)
        {
            var result = from pInfo in _context.Applications
                         join p in _context.Programs on pInfo.Id equals p.UserApplicationId
                         where pInfo.IsDeleted == 0 && pInfo.Id == Id
                         select new ApplicationResponseDto
                         {
                             FirstName = pInfo.FirstName,
                             LastName = pInfo.LastName,
                             Email = pInfo.Email,
                             PhoneNumber = pInfo.PhoneNumber,
                             Gender = pInfo.Gender,
                             Nationality = pInfo.Nationality,
                             DateMovedToUK = pInfo.DateMovedToUK,
                             DateOfBirth = pInfo.DateOfBirth,
                             IDNumber = pInfo.IDNumber,
                             SpecifyOther = pInfo.SpecifyOther,
                             Residence = pInfo.Residence,
                             ProgramTitle = p.ProgramTitle,
                             ProgramDescription = p.ProgramDescription,

                             QuestionAndAnswers =pInfo.QuestionAndAnswers.Where(x=> x.Email == pInfo.Email)
                             .Select(x => new QuestionAndAnswerDto
                             {
                                 Question = x.Question,
                                 Answer = x.Answer,
                             })
                             

                         };

            return result.FirstOrDefaultAsync();
        }

        public Task<List<ApplicationResponseDto>> GetApplications()
        {
            var result = from pInfo in _context.Applications
                         join p in _context.Programs on pInfo.Id equals p.UserApplicationId
                         where pInfo.IsDeleted == 0
                         select new ApplicationResponseDto
                         {
                             FirstName = pInfo.FirstName,
                             LastName = pInfo.LastName,
                             Email = pInfo.Email,
                             PhoneNumber = pInfo.PhoneNumber,
                             Gender = pInfo.Gender,
                             Nationality = pInfo.Nationality,
                             DateMovedToUK = pInfo.DateMovedToUK,
                             DateOfBirth = pInfo.DateOfBirth,
                             IDNumber = pInfo.IDNumber,
                             SpecifyOther = pInfo.SpecifyOther,
                             Residence = pInfo.Residence,
                             ProgramTitle = p.ProgramTitle,
                             ProgramDescription = p.ProgramDescription,
                             QuestionAndAnswers = pInfo.QuestionAndAnswers.Where(x => x.Email == pInfo.Email)
                             .Select(x => new QuestionAndAnswerDto
                             {
                                 Question = x.Question,
                                 Answer = x.Answer,
                             })

                         };

            return result.AsNoTracking().ToListAsync();
        }
    }
}
