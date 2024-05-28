using Microsoft.EntityFrameworkCore;
using Zanime.Server.Data.Services.Interfaces;
using Zanime.Server.Models.Main;
using Zanime.Server.Models.Main.DTO.Character_Model;

namespace Zanime.Server.Data.Services
{
    public class CharacterService : ICharacterService
    {
        private readonly ApplicationDbContext _context;

        public CharacterService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Character>> GetAll()
        {
            var characters = await _context.Characters.ToListAsync();
            return (characters);
        }

        public async Task<Character> GetByID(int CharacterID)
        {
            var character = await _context.Characters.FirstOrDefaultAsync(c => c.ID == CharacterID);
            return (character);
        }

        public async Task<Character> GetByName(string Name)
        {
            var character = await _context.Characters.FirstOrDefaultAsync(c => c.Name == Name);
            return (character);
        }

        public async Task<Character> Post(CharacterVM model)
        {
            Character character = new Character
            {
                Name = model.Name,
                Age = model.Age,
                Gender = model.Gender,
                PicturePath = model.PicturePath,
                Bio = model.Bio,
                Likes = 0,
                Dislikes = 0,
            };

            await _context.Characters.AddAsync(character);
            await _context.SaveChangesAsync();

            return (character);
        }

        public async Task<Character> Put(CharacterVM model, int characterID)
        {
            var character = await _context.Characters.FirstOrDefaultAsync(c => c.ID == characterID);

            character.Name = model.Name;
            character.Age = model.Age;
            character.Gender = model.Gender;
            character.PicturePath = model.PicturePath;
            character.Bio = model.Bio;

            await _context.SaveChangesAsync();

            return (character);
        }

        public async Task<string> Delete(Character model)
        {
            _context.Characters.Remove(model);
            await _context.SaveChangesAsync();

            return ("Record Deleted");
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}