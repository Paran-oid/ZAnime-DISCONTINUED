using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Zanime.Server.Models.Main.Attributes;
using Zanime.Server.Models.Main.Relationships;

namespace Zanime.Server.Models.Main
{
    public class Anime
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }

        [Required(ErrorMessage = "ReleaseDate is required")]
        public DateOnly ReleaseDate { get; set; }

        [DateValidationAnime]
        public DateOnly? EndDate { get; set; } = null;

        [Required(ErrorMessage = "PicturePath is required")]
        public string PicturePath { get; set; }

        [Required(ErrorMessage = "Title is required")]
        public string BackgroundPath { get; set; }

        [Required(ErrorMessage = "Title is required")]
        public string Description { get; set; }

        [Range(0, 5, ErrorMessage = "Rating must be between 0 and 5")]
        public double Rating { get; set; } = 0;

        public ICollection<AnimeGenre> AnimeGenre { get; set; }
        public ICollection<AnimeActor> AnimeActor { get; set; }

        public ICollection<AnimeCharacter> AnimeCharacter { get; set; }

        public ICollection<Comment> Comments { get; set; }
    }
}