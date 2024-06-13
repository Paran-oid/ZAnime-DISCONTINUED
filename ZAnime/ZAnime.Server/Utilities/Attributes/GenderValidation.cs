using System.ComponentModel.DataAnnotations;

namespace Zanime.Server.Utilities.Attributes
{
    //We defined the attribute
    public class GenderValidation : ValidationAttribute
    {
        private readonly string[] _validGenders;

        public GenderValidation(params string[] validGenders)
        {
            _validGenders = validGenders;
        }

        //We added the valid genders to our class

        //We have this method to validate our Actors/Characters

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            //If the value is null or the valid genders array doesnt contain the value the user entered ( we ignore the upper/lower cases)
            if (value == null || !_validGenders.Contains(value.ToString(), StringComparer.OrdinalIgnoreCase))
            {
                return new ValidationResult("Invalid gender value, allowed values are " + string.Join(", ", _validGenders));
            }
            return ValidationResult.Success;
        }
    }
}