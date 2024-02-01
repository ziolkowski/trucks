using FluentValidation.Results;

namespace Trucks.Utilities
{
    public static class ValidationHelper
    {
        public static string GetFailedValidationMessage(ValidationResult result) 
        {
            string errorMessage = string.Empty;
            foreach (var error in result.Errors)
            {
                errorMessage += $"{error.ErrorMessage}\n";
            }

            return errorMessage;
        }
    }
}
