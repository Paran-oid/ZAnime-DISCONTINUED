using System.ComponentModel.DataAnnotations;
using Zanime.Server.Utilities.Attributes;

namespace Zanime.Server.Models.Main.DTO.Character_Model
{
    public class CharacterVM
    {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, ErrorMessage = "Name can't be longer than 50 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Age is required")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Gender is required")]
        [GenderValidation("Male", "Female", "Other")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "PicturePath is required")]
        [PathValidation<CharacterVM>]
        public string PicturePath { get; set; }

        [Required(ErrorMessage = "Bio is required")]
        public string Bio { get; set; }
    }
}