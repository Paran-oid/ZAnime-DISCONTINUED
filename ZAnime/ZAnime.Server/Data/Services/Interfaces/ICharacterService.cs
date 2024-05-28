using Zanime.Server.Models.Main.DTO.Actor_Model;
using Zanime.Server.Models.Main;
using Zanime.Server.Models.Main.DTO.Character_Model;

namespace Zanime.Server.Data.Services.Interfaces
{
    public interface ICharacterService
    {
        public Task<IEnumerable<Character>> GetAll();

        public Task<Character> GetByID(int characterID);

        public Task<Character> GetByName(string Name);

        public Task<Character> Post(CharacterVM model);

        public Task<Character> Put(CharacterVM model, int characterID);

        public Task<string> Delete(Character model);

        Task SaveChanges();
    }
}