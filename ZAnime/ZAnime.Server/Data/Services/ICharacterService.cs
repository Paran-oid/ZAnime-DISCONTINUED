using Zanime.Server.Models.Main.DTO.Actor_Model;
using Zanime.Server.Models.Main;
using Zanime.Server.Models.Main.DTO.Character_Model;

namespace Zanime.Server.Data.Services
{
    public interface ICharacterService
    {
        public Task<IEnumerable<Character>> GetAll();

        public Task<Character> Get(int CharacterID);

        public Task<Character> Post(CharacterVM model);

        public Task<Character> Put(CharacterVM model, int ActorID);

        public Task Delete(Character model);
    }
}