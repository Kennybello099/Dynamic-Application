using Dynamic_Application.Common;

namespace Dynamic_Application.model
{
    public class Programs : BaseEntity
    {
        public string? ProgramTitle { get; set; }

        public string? ProgramDescription { get; set; }

        public long? UserApplicationId { get; set; }
        public UserApplication? UserApplication { get; set; }

        public string? Email { get; set; }

    }
}
