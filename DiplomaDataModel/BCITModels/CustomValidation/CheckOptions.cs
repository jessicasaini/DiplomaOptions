using OptionsWebsite.Models.BCITModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaDataModel.BCITModels.CustomValidation
{
    class CheckOptions : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {

            Choice choice = value as Choice;

            HashSet<int> OptionIds = new HashSet<int>();
            OptionIds.Add((int)choice.FirstChoiceOptionId);
            OptionIds.Add((int)choice.SecondChoiceOptionId);
            OptionIds.Add((int)choice.ThirdChoiceOptionId);
            OptionIds.Add((int)choice.FourthChoiceOptionId);

            if (OptionIds.Count == 4)
            {
                return ValidationResult.Success;
            }
            else {
                var errorMessage = FormatErrorMessage(validationContext.DisplayName);
                return new ValidationResult(errorMessage);
            }
        }
    }
}