
using Dynamic_Application.AppContext;

namespace Dynamic_Application.Repository
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ApplicationData _context;
        public IApplicationRepo ApplicationRepo { get; set; }

        public IProgramRepo ProgramRepo { get; set; }

        public IQuestionAndAnswerRepo questionAndAnswerRepo { get; set; }

        public UnitOfWork(ApplicationData context, 
            IApplicationRepo applicationRepo, 
            IProgramRepo programRepo)
        {
            _context = context;
            ApplicationRepo = applicationRepo;
            ProgramRepo = programRepo;
        }


        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
        public virtual void Dispose(bool disposing)
        {
            if(disposing)
            {
                _context.Dispose();
            }
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync(); 
        }
    }
}
