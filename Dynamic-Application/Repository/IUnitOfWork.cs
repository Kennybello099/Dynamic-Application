namespace Dynamic_Application.Repository
{
    public interface IUnitOfWork
    {
        IApplicationRepo ApplicationRepo { get; }

        IProgramRepo ProgramRepo { get; }

        IQuestionAndAnswerRepo questionAndAnswerRepo { get; }
        Task<int> SaveAsync();
    }
}
