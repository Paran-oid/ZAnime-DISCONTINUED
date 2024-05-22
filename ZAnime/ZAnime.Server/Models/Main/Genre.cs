using Zanime.Server.Models.Main.Relationships;

namespace Zanime.Server.Models.Main
{
    public class Genre
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public ICollection<AnimeGenre> AnimeGenre { get; set;}
    }
}