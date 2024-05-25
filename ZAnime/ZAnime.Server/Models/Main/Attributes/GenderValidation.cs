using System.ComponentModel.DataAnnotations;

namespace Zanime.Server.Models.Main.Attributes
{
    public class GenderValidation : ValidationAttribute
    {
        private readonly string[] _validGenders;

        public GenderValidation(params string[] validGenders)
        {
            _validGenders = validGenders;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null || !_validGenders.Contains(value.ToString(), StringComparer.OrdinalIgnoreCase))
            {
                return new ValidationResult("Invalid gender value, allowed values are " + String.Join(", ", _validGenders));
            }
            return ValidationResult.Success;
        }
    }
}