using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Zanime.Server.Data.Services.Interfaces;
using Zanime.Server.Data.Services.Interfaces.AppRelated;
using Zanime.Server.Models.Main;
using Zanime.Server.Models.Main.DTO.Actor_Model;
using Zanime.Server.Models.Main.DTO.Character_Model;

namespace Zanime.Server.Data.Services
{
    public class CharacterService : ICharacterService
    {
        private readonly ApplicationDbContext _context;
        private readonly ICacheService _cacheService;
        private readonly IMapper _mapper;

        public CharacterService(
            ApplicationDbContext context,
            IMapper mapper,
            ICacheService cacheService)
        {
            _context = context;
            _mapper = mapper;
            _cacheService = cacheService;
        }

        public async Task<IEnumerable<Character>> GetAll()
        {
            string key = "GetAllCharacters";
            var data = _cacheService.GetData<IEnumerable<Character>>(key);

            if (data == null)
            {
                DateTimeOffset expire = DateTimeOffset.Now.AddMinutes(5);
                data = await _context.Characters.ToListAsync();
                _cacheService.SetData(key, data, expire);
                return (data);
            }

            return (data);
        }

        public async Task<Character> GetID(int characterID)
        {
            string key = $"character{characterID}";
            var data = _cacheService.GetData<Character>(key);

            if (data == null)
            {
                data = await _context.Characters.FirstOrDefaultAsync(a => a.ID == characterID);

                if (data == null)
                {
                    return default;
                }

                DateTimeOffset expire = DateTime.Now.AddMinutes(5);
                _cacheService.SetData<Character>(key, data, expire);
                return (data);
            }
            return (data);
        }

        public async Task<Character> GetbyName(string name)
        {
            string key = $"character {name}";
            var data = _cacheService.GetData<Character>(key);

            if (data == null)
            {
                DateTimeOffset expire = DateTimeOffset.Now.AddMinutes(5);
                data = await _context.Characters.FirstOrDefaultAsync(a => a.Name == name);
                _cacheService.SetData<Character>(key, data, expire);
                return (data);
            }
            return (data);
        }

        public async Task<Character> Post(CharacterVM model)
        {
            Character character = _mapper.Map<Character>(model);

            await _context.Characters.AddAsync(character);
            await _context.SaveChangesAsync();

            DateTimeOffset expire = DateTimeOffset.Now.AddMinutes(5);

            string key = $"character{character.ID}";
            _cacheService.SetData(key, character, expire);

            key = $"character {character.Name}";
            _cacheService.SetData(key, character, expire);

            _cacheService.RemoveData("GetAllCharacters");

            return (character);
        }

        public async Task<Character> Put(CharacterVM model, int characterID)
        {
            var character = await _context.Characters.FirstOrDefaultAsync(c => c.ID == characterID);
            string key;

            DateTimeOffset expire = DateTimeOffset.Now.AddMinutes(5);
            character = _mapper.Map(model, character);

            key = $"character{character.ID}";
            _cacheService.SetData(key, character, expire);

            key = $"character {character.Name}";
            _cacheService.SetData(key, character, expire);

            _cacheService.RemoveData("GetAllCharacters");

            await _context.SaveChangesAsync();

            return (character);
        }

        public async Task<string> Delete(Character model)
        {
            _context.Characters.Remove(model);
            await _context.SaveChangesAsync();

            string key;

            key = $"character {model.Name}";
            _cacheService.RemoveData(key);

            key = $"character{model.ID}";
            _cacheService.RemoveData(key);

            _cacheService.RemoveData("GetAllCharacters");

            return ("Record Deleted");
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}