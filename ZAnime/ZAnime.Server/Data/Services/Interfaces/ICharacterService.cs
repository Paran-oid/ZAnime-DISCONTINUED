using Zanime.Server.Models.Main.DTO.Actor_Model;
using Zanime.Server.Models.Main;
using Zanime.Server.Models.Main.DTO.Character_Model;

namespace Zanime.Server.Data.Services.Interfaces
{
    public interface ICharacterService
    {
        public Task<IEnumerable<Character>> GetAll();

        public Task<Character> GetID(int characterID);

        public Task<Character> GetbyName(string name);

        public Task<Character> Post(CharacterVM model);

        public Task<Character> Put(CharacterVM model, int characterID);

        public Task<string> Delete(Character model);

        Task SaveChanges();
    }
}