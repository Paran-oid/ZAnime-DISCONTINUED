using Zanime.Server.Models.Main;
using Zanime.Server.Models.Main.DTO.Actor_Model;
using Zanime.Server.Models.Main.DTO.Character_Model;
using Zanime.Server.Models.Main.Relationships;

namespace Zanime.Server.Data.Services.Interfaces
{
    public interface IActorRelationships
    {
        public Task<ActorCharacter> GetActorCharacter(int actorID, int characterID);

        public Task<Character> GetCharacterWithActor(int characterID);

        public Task<Actor> GetActorWithCharacter(int actorID);

        public Task<IEnumerable<CharacterVM>> GetCharacters(int actorID);

        public Task<IEnumerable<ActorVM>> GetActors(int characterID);

        public Task<string> CreateActorToCharacter(Character character, ActorVM model);

        public Task<string> CreateCharacterToActor(Actor actor, CharacterVM model);

        public Task<string> AddCharacterToActor(Actor actor, Character character);

        public Task<string> Delete(ActorCharacter relationship);
    }
}