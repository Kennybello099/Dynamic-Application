using Dynamic_Application.Repository;

namespace Dynamic_Application.Service
{
    public class QuestionAndAnswerService : IQuestionAndAnswerService
    {
        private readonly IUnitOfWork _unitofWork;
        public QuestionAndAnswerService(IUnitOfWork unitofWork)
        {
            _unitofWork = unitofWork;

        }
    }
}
