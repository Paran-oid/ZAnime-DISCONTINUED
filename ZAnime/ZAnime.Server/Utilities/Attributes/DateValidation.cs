using System.ComponentModel.DataAnnotations;
using Zanime.Server.Models.Main.DTO.Anime_Model;

namespace Zanime.Server.Utilities.Attributes
{
    public class DateValidationAnime : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            //we get the value from end date property
            DateOnly? endate = (DateOnly?)value;
            //we navigate to release date through validation context.objectinstance
            DateOnly releasedate = ((AnimeVM)validationContext.ObjectInstance).ReleaseDate;

            if (releasedate.Year < 1917)
            {
                return new ValidationResult("release date can't be before 1917");
            }
            else if (endate.HasValue && endate < releasedate)
            {
                return new ValidationResult("release date can't be after the end date");
            }

            return ValidationResult.Success;
        }
    }
}