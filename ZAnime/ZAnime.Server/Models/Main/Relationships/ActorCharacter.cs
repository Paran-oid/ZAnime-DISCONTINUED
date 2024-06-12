using System.ComponentModel.DataAnnotations.Schema;

namespace Zanime.Server.Models.Main.Relationships
{
    [Table("ActorCharacters", Schema = "anr")]
    public class ActorCharacter
    {
        public int ActorID { get; set; }
        public Actor Actor { get; set; }
        public int CharacterID { get; set; }
        public Character Character { get; set; }
    }
}