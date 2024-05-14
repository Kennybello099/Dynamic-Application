using Dynamic_Application.Common;
using Dynamic_Application.Enum;

namespace Dynamic_Application.model
{
    public class UserApplication : BaseEntity
    {
        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Email { get; set; }

        public string? PhoneNumber { get; set; }

        public string? Nationality { get; set; }

        public string? Residence { get; set; }

        public string? DateOfBirth { get; set; }

        public string? Gender { get; set;  }

        public string? AboutYourSelf { get; set; }

      

        public int YearsOfExperience { get; set; }

        public bool IsRejectedByUKEmbassasy { get; set; }

        public string? DateMovedToUK { get; set; }

        public string? SpecifyOther { get; set; }

        public int IDNumber { get; set; }

        public long? ProgramId { get; set; }
        public Programs? Program { get; set; }

        public long? QuestionAndAnswerId { get; set; }
        public ICollection<QuestionAndAnswer>? QuestionAndAnswers { get; set; }
    }
}

