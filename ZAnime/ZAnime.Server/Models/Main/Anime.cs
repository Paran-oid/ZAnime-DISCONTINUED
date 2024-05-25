using System.ComponentModel.DataAnnotations;
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

        public DateOnly? EndDate { get; set; } = null;

        [Required(ErrorMessage = "PicturePath is required")]
        public string PicturePath { get; set; }

        [Required(ErrorMessage = "Title is required")]
        public string BackgroundPath { get; set; }

        [Required(ErrorMessage = "Title is required")]
        public string Description { get; set; }

        public float Rating { get; set; } = 0;

        public ICollection<AnimeGenre> AnimeGenre { get; set; }
        public ICollection<AnimeActor> AnimeActor { get; set; }

        public ICollection<AnimeCharacter> AnimeCharacter { get; set; }

        public ICollection<Comment> Comments { get; set; }
    }
}