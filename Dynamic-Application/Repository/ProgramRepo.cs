using Dynamic_Application.AppContext;
using Dynamic_Application.model;

namespace Dynamic_Application.Repository
{
    public class ProgramRepo : GenericRepository<Programs>, IProgramRepo
    {
        public ProgramRepo(ApplicationData _context) : base(_context) { }
    
    }
}
