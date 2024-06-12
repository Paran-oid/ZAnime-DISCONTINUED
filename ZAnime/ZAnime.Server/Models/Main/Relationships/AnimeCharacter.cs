using System.ComponentModel.DataAnnotations.Schema;

namespace Zanime.Server.Models.Main.Relationships
{
    [Table("AnimeCharacters", Schema = "anr")]
    public class AnimeCharacter
    {
        public int AnimeID { get; set; }
        public Anime Anime { get; set; }
        public int CharacterID { get; set; }
        public Character Character { get; set; }
    }
}