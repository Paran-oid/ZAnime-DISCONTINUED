namespace Zanime.Server.Models.Main.Relationships
{
    public class ActorCharacter
    {
        public int ActorID { get; set; }
        public Actor Actor { get; set; }
        public int CharacterID { get; set; }
        public Character Character { get; set; }
    }
}