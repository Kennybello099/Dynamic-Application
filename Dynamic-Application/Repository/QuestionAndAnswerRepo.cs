using Dynamic_Application.AppContext;
using Dynamic_Application.DTOs;
using Dynamic_Application.model;

namespace Dynamic_Application.Repository
{
    public class QuestionAndAnswerRepo : GenericRepository<QuestionAndAnswer>, IQuestionAndAnswerRepo
    {
        public QuestionAndAnswerRepo(ApplicationData _context) : base(_context) { }

        public async Task AddQuestionAndAnswer(ApplicationRequestDto model)
        {

            foreach (var item in model.QuestionAndAnswer)
            {
                QuestionAndAnswer questionAndAnswer = _context.questionAndAnswers.FirstOrDefault(x => x.Email == model.Email);

                questionAndAnswer.Question = item.Question;
                questionAndAnswer.Answer = item.Answer;
                _context.questionAndAnswers.Add(questionAndAnswer);

            }
        }

        public async Task UpdateQuestionAndAnswer(UpdateApplicationDto model)
        {
            foreach (var item in model.QuestionAndAnswers)
            {
                QuestionAndAnswer questionAndAnswer = _context.questionAndAnswers.FirstOrDefault(x => x.UserApplicationId == model.UserId);

                questionAndAnswer.Question = item.Question;
                questionAndAnswer.Answer = item.Answer;
                _context.questionAndAnswers.Add(questionAndAnswer);

            }
        }
    }
}
