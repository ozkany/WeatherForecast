using System.ComponentModel.DataAnnotations;

namespace WeatherForecast.Domain.Validators
{
    public class FutureDateAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is DateTime date)
            {
                if (date >= DateTime.Today)
                {
                    return ValidationResult.Success;
                }
            }

            return new ValidationResult($"The {validationContext.DisplayName} field cannot be a past date.");
        }
    }
}
