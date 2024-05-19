namespace Zanime.Server.Models.Main.Relationships
{
    public class AnimeCharacter
    {
        public int AnimeID { get; set; }
        public Anime Anime { get; set; }
        public int CharacterID { get; set; }
        public Character Character { get; set; }
    }
}