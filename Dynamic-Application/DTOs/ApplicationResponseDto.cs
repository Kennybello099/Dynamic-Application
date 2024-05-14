using Dynamic_Application.Enum;
using Dynamic_Application.model;
using Dynamic_Application.Utility;
using System.ComponentModel.DataAnnotations;

namespace Dynamic_Application.DTOs
{
    public class ApplicationResponseDto
    {

        public string? ProgramTitle { get; set; }

        public string? ProgramDescription { get; set; }
        public string? FirstName { get; set; }

        public string? LastName { get; set; }

      
        public string? Email { get; set; }

        public string? PhoneNumber { get; set; }

        public string? Nationality { get; set; }

        public string? Residence { get; set; }

        public string? DateOfBirth { get; set; }

        public string? Gender { get; set; }

        public string? AboutYourSelf { get; set; }

        public int GraduationYear { get; set; }

        public int IDNumber { get; set; }
        public string? Personality { get; set; }

        public int YearsOfExperience { get; set; }

        public bool IsRejectedByUKEmbassasy { get; set; }

        public string? DateMovedToUK { get; set; }

        public string? SpecifyOther { get; set; }

        public IEnumerable<QuestionAndAnswerDto>? QuestionAndAnswers { get; set; }
    }
}
