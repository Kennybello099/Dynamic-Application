using Dynamic_Application.Common;
using Dynamic_Application.Enum;

namespace Dynamic_Application.model
{
    public class QuestionAndAnswer : BaseEntity
    {
        public string? Question { get; set; }

        public string? Answer { get; set; }

        public long? UserApplicationId { get; set; }
        public UserApplication? UserApplication { get; set; }

      public string? Email { get; set; }

    }
}
