using System.ComponentModel.DataAnnotations.Schema;

namespace Zanime.Server.Models.Main.Relationships
{
    [Table("ActorGenres", Schema = "anr")]
    public class AnimeGenre
    {
        public int AnimeID { get; set; }
        public Anime Anime { get; set; }

        public int GenreID { get; set; }
        public Genre Genre { get; set; }
    }
}