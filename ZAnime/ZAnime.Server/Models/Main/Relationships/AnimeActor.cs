using System.ComponentModel.DataAnnotations.Schema;

namespace Zanime.Server.Models.Main.Relationships
{
    [Table("AnimeActors", Schema = "anr")]
    public class AnimeActor
    {
        public int AnimeID { get; set; }
        public Anime Anime { get; set; }
        public int ActorID { get; set; }
        public Actor Actor { get; set; }
    }
}