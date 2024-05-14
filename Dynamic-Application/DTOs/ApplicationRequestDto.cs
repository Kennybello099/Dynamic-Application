using Dynamic_Application.Enum;
using Dynamic_Application.model;
using Dynamic_Application.Utility;
using System.ComponentModel.DataAnnotations;

namespace Dynamic_Application.DTOs
{
    public class ApplicationRequestDto
    {
        [Required]
        public string? ProgramTitle { get; set; }

        [Required]
        public string? ProgramDescription { get; set; }


        [Required]
        public string? FirstName { get; set; }

        [Required]
        public string? LastName { get; set; }

        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        public string? PhoneNumber { get; set; }

        [Required]
        public string? Nationality { get; set; }

        [Required]
        public string? Residence { get; set; }

        [Required]
        public string? DateOfBirth { get; set; }

        public Gender Gender { get; set; }

        public int IDNumber { get; set; }

        public List<QuestionAndAnswerDto>? QuestionAndAnswer { get; set; }


    }
}
