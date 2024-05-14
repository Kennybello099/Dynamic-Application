using Dynamic_Application.Enum;
using Dynamic_Application.Utility;
using System.ComponentModel.DataAnnotations;

namespace Dynamic_Application.DTOs
{
    public class UpdateApplicationDto
    {
        public long UserId { get; set; }

        public string? ProgramTitle { get; set; }

        public string? ProgramDescription { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }
        public string? Email { get; set; }

        public string? PhoneNumber { get; set; }

        public string? Nationality { get; set; }

        public string? Residence { get; set; }

        public string? DateOfBirth { get; set; }

        public Gender Gender { get; set; }

        public int IDNumber { get; set; }

        public List<QuestionAndAnswerDto>? QuestionAndAnswers { get; set; }
    }
}
