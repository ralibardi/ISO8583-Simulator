using FluentValidation.Results;

namespace SecretWeapon.Tools.Validation
{
    public static class ValidationResultExtensions
    {
        public static bool HasErrors(this ValidationResult result)
        {
            return !result.IsValid;
        }

        //public static bool HasWarnings(this ValidationResult result);

        //public static ValidationResult Merge(this ValidationResult resultA, ValidationResult resultB);

    }
}