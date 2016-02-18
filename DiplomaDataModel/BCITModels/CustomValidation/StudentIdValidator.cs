using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace MVC01.Models.CustomValidation
{
    public class StudentIdValidator : ValidationAttribute
    {
        private readonly int _n;
        public StudentIdValidator(int n) : base("{0} must start with A00, followed by 6 numbers")
        {
            _n = n;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                
                var stringval = value.ToString();
                if (stringval.Length != _n) {
                    var errorMessage = FormatErrorMessage(validationContext.DisplayName);
                    return new ValidationResult(errorMessage);
                }
                string start = stringval.Substring(0,3);
                string end = stringval.Substring(stringval.Length - 6);
                if (start != "A00" && start != "a00") {
                    var errorMessage = FormatErrorMessage(validationContext.DisplayName);
                    return new ValidationResult(errorMessage);
                }
                if (!end.All(char.IsDigit))
                {
                    var errorMessage = FormatErrorMessage(validationContext.DisplayName);
                    return new ValidationResult(errorMessage);
                }

            }
            return ValidationResult.Success;

        }
    }
}