using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Zanime.Server.Data.Services.Interfaces;
using Zanime.Server.Data.Services.Interfaces.AppRelated;
using Zanime.Server.Models.Main;
using Zanime.Server.Models.Main.DTO.Genre_Model;

namespace Zanime.Server.Data.Services
{
    public class GenreService : IGenreService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ICacheService _cacheService;

        public GenreService(
            ApplicationDbContext context,
            IMapper mapper,
            ICacheService cacheService)
        {
            _context = context;
            _mapper = mapper;
            _cacheService = cacheService;
        }

        public async Task<IEnumerable<Genre>> GetAll()
        {
            string key = "GetAllGenres";

            var data = _cacheService.GetData<IEnumerable<Genre>>(key);

            if (data == null)
            {
                DateTimeOffset expire = DateTimeOffset.Now.AddMinutes(5);
                data = await _context.Genres.ToListAsync();
                _cacheService.SetData(key, data, expire);
                return (data);
            }
            return (data);
        }

        public async Task<Genre> GetID(int genreID)
        {
            string key = $"Genre{genreID}";
            var data = _cacheService.GetData<Genre>(key);

            if (data == null)
            {
                DateTimeOffset expire = DateTimeOffset.Now.AddMinutes(5);
                data = await _context.Genres.FirstOrDefaultAsync(g => g.ID == genreID);
                _cacheService.SetData<Genre>(key, data, expire);
                return (data);
            }
            return (data);
        }

        public async Task<Genre> GetbyName(string name)
        {
            string key = $"Genre {name}";
            var data = _cacheService.GetData<Genre>(key);

            if (data == null)
            {
                DateTimeOffset expire = DateTimeOffset.Now.AddMinutes(5);
                data = await _context.Genres.FirstOrDefaultAsync(g => g.Name == name);
                _cacheService.SetData(key, data, expire);
                return (data);
            }
            return (data);
        }

        public async Task<Genre> Post(GenreVM model)
        {
            Genre data = new Genre
            {
                Name = model.Name,
            };

            string key;

            await _context.Genres.AddAsync(data);
            await _context.SaveChangesAsync();

            DateTimeOffset expire = DateTimeOffset.Now.AddMinutes(5);

            key = $"Genre {model.Name}";
            _cacheService.SetData(key, data, expire);

            key = $"Genre{data.Name}";
            _cacheService.SetData(key, data, expire);

            _cacheService.RemoveData("GetAllGenres");

            return (data);
        }

        public async Task<Genre> Put(GenreVM model, int genreID)
        {
            var data = await _context.Genres.FirstOrDefaultAsync(c => c.ID == genreID);

            DateTimeOffset expire = DateTimeOffset.Now.AddMinutes(5);
            string key;

            data.Name = model.Name;

            _context.Update(data);
            await _context.SaveChangesAsync();

            key = $"Genre {data.Name}";
            _cacheService.SetData(key, data, expire);

            key = $"Genre{data.ID}";
            _cacheService.SetData(key, data, expire);

            _cacheService.RemoveData("GetAllGenres");

            return (data);
        }

        public async Task<string> Delete(Genre model)
        {
            _context.Genres.Remove(model);
            await _context.SaveChangesAsync();

            string key;
            key = $"Genre{model.ID}";
            _cacheService.RemoveData(key);

            key = $"Genre {model.Name}";
            _cacheService.RemoveData(key);

            _cacheService.RemoveData("GetAllUsers");

            return ("Record Deleted");
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}