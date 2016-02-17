using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace MVC01.Models.CustomValidation
{
    public class StudentIdValidator : ValidationAttribute
    {

        public StudentIdValidator() : base("Id must start with A00 and be 9 characters long")
        {
           
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {

            if (value != null)
            {

                char[] delimiters = new char[] { ' ', '\r', '\n' };
                var stringVal = value.ToString();
                int x = stringVal.Split(delimiters, StringSplitOptions.RemoveEmptyEntries).Length;

                if (false)
                {
                    var errorMessage = FormatErrorMessage(validationContext.DisplayName);
                    return new ValidationResult(errorMessage);

                }
            }
            return ValidationResult.Success;
        }
    }
}