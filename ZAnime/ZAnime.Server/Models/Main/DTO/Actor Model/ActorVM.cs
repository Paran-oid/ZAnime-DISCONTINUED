using System.ComponentModel.DataAnnotations;
using Zanime.Server.Models.Main.Attributes;

namespace Zanime.Server.Models.Main.DTO.Actor_Model
{
    public class ActorVM
    {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, ErrorMessage = "Name can't be longer than 50 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Age is required")]
        [Range(16, 100, ErrorMessage = "Age must be between 16 and 100")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Gender is required")]
        [GenderValidation("Male", "Female", "Other")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "PicturePath is required")]
        public string PicturePath { get; set; }

        [Required(ErrorMessage = "Bio is required")]
        public string Bio { get; set; }
    }
}