using System;
using System.ComponentModel.DataAnnotations;


namespace SaphyreDemo.Helpers
{

    public class CustomDateValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime? inputDate = value as DateTime?;

            if (!inputDate.HasValue)
            {
                return new ValidationResult("Date is required.");
            }

            if (inputDate.Value.Date > DateTime.UtcNow.Date)
            {
                return new ValidationResult("Date cannot be in the future.");
            }

            return ValidationResult.Success;
        }
    }

}
