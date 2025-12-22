using System.ComponentModel.DataAnnotations;

namespace AppAgency.ASP.Models.DataAnnotation
{
    public class NotEarlierThanNowAttribute : ValidationAttribute
    {
        public NotEarlierThanNowAttribute()
        {
            // Set a default error message
            ErrorMessage = "The date cannot be earlier than the current date.";
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            // Check if value is null (handle nullable DateTime)
            if (value == null)
            {
                return ValidationResult.Success;  // You can adjust this if you want to validate null as invalid
            }

            // Convert the value to DateTime
            DateTime givenDate = (DateTime)value;

            // Get the current date and time
            DateTime currentDate = DateTime.Now;

            // If the given date is earlier than the current date, return a validation error
            if (givenDate < currentDate)
            {
                return new ValidationResult(ErrorMessage);
            }

            // If the date is valid, return success
            return ValidationResult.Success;
        }
    }
}
