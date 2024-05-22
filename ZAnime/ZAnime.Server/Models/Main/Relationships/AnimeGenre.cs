namespace Zanime.Server.Models.Main.Relationships
{
    public class AnimeGenre
    {
        public int AnimeID { get; set; }
        public Anime Anime { get; set; }

        public int GenreID { get; set; }
        public Genre Genre { get; set; }
    }
}
