using Zanime.Server.Models.Main.Relationships;

namespace Zanime.Server.Models.Main
{
    public class Anime
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public DateOnly ReleaseDate { get; set; }
        public DateOnly? EndDate { get; set; } = null;
        public string PicturePath { get; set; }
        public string BackgroundPath { get; set; }
        public string Description { get; set; }
        public float Rating { get; set; }

        public ICollection<AnimeGenre> AnimeGenre { get; set; }
        public ICollection<AnimeActor> AnimeActor { get; set; }

        public ICollection<AnimeCharacter> AnimeCharacter { get; set; }

        public ICollection<AnimeComment> AnimeComment { get; set; }
    }
}