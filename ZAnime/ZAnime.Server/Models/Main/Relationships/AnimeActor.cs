namespace Zanime.Server.Models.Main.Relationships
{
    public class AnimeActor
    {
        public int AnimeID { get; set; }
        public Anime Anime { get; set; }
        public int ActorID { get; set; }
        public Actor Actor { get; set; }
    }
}