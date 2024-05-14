using System.ComponentModel.DataAnnotations;
using static System.Net.Mime.MediaTypeNames;

namespace Dynamic_Application.Utility
{
    public partial class ValidationExtensionsAttribute : ValidationAttribute
    {
        private readonly int _maxWord;

        public ValidationExtensionsAttribute(int maxWord)
        {
            _maxWord = maxWord;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var text = value as string;
            char[] punctuationCharacters = text.Where(char.IsPunctuation).Distinct().ToArray();
            var words = text.Split().Select(x => x.Trim(punctuationCharacters));
            var noOfWords = words.Where(x => !string.IsNullOrWhiteSpace(x)).Count();
            if (noOfWords > _maxWord)
            {
                return new ValidationResult("The number of words input is more than 500 words.");
            }
            return ValidationResult.Success;
        }
    }
}
