using System.ComponentModel.DataAnnotations;
using Zanime.Server.Models.Main.Attributes;
using Zanime.Server.Models.Main.Relationships;

namespace Zanime.Server.Models.Main
{
    public class Character
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, ErrorMessage = "Name can't be longer than 50 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Age is required")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Gender is required")]
        [GenderValidation("Male", "Female", "Other")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "PicturePath is required")]
        public string PicturePath { get; set; }

        [Required(ErrorMessage = "Bio is required")]
        public string Bio { get; set; }

        public int Likes { get; set; } = 0;
        public int Dislikes { get; set; } = 0;

        //One anime character can have many actors or can even not have one
        public ICollection<ActorCharacter>? ActorCharacters { get; set; }

        public ICollection<AnimeCharacter> AnimeCharacter { get; set; }
    }
}