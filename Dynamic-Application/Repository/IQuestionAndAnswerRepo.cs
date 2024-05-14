using Dynamic_Application.DTOs;
using Dynamic_Application.model;
using Microsoft.EntityFrameworkCore;

namespace Dynamic_Application.Repository
{
    public interface IQuestionAndAnswerRepo : IGenericRepository<QuestionAndAnswer>
    {
        Task UpdateQuestionAndAnswer(UpdateApplicationDto model);

        Task AddQuestionAndAnswer(ApplicationRequestDto model);

    }
}
