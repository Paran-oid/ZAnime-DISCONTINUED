using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Zanime.Server.Data.Services.Interfaces;
using Zanime.Server.Data.Services.Interfaces.AppRelated;
using Zanime.Server.Models.Main;
using Zanime.Server.Models.Main.DTO.Anime_Model;
using Zanime.Server.Models.Main.DTO.Comment_Model;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Zanime.Server.Data.Services
{
    public class AnimeService : IAnimeService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ICacheService _cacheService;

        public AnimeService(ApplicationDbContext context
            IMapper mapper,
            ICacheService cacheService)
        {
            _context = context;
            _cacheService = cacheService;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AnimeVM>> GetAll()
        {
            string key = "GetAllAnimes";
            var data = _cacheService.GetData<IEnumerable<AnimeVM>>(key);

            if (data == null)
            {
                DateTimeOffset expire = DateTimeOffset.Now.AddMinutes(5);

                var newData = await _context.Animes
                    .Select(anime => _mapper.Map<AnimeVM>(anime))
                    .ToListAsync();

                _cacheService.SetData(key, newData, expire);
                return (newData);
            }
            return (data);
        }

        public async Task<Anime> GetID(int animeID)
        {
            string key = $"anime{animeID}";
            var data = _cacheService.GetData<Anime>(key);

            if (data == null)
            {
                DateTimeOffset expire = DateTimeOffset.Now.AddMinutes(5);
                data = await _context.Animes.FirstOrDefaultAsync(a => a.ID == animeID);
                _cacheService.SetData(key, data, expire);
                return (data);
            }
            return (data);
        }

        public async Task<Anime> GetbyTitle(string title)
        {
            string key = $"anime {title}";
            var data = _cacheService.GetData<Anime>(key);

            if (data == null)
            {
                DateTimeOffset expire = DateTimeOffset.Now.AddMinutes(5);
                data = await _context.Animes.FirstOrDefaultAsync(a => a.Title == title);
                _cacheService.SetData(key, data, expire);
                return (data);
            }
            return (data);
        }

        public async Task<IEnumerable<CommentAnimeVM>> GetComments(int animeID)
        {
            string key = $"anime{animeID} comments";
            var data = _cacheService.GetData<IEnumerable<CommentAnimeVM>>(key);

            if (data == null)
            {
                DateTimeOffset expire = DateTimeOffset.Now.AddMinutes(5);
                var newData = await _context.Comments
                    .Where(c => c.AnimeID == animeID)
                    .Select(c => _mapper.Map<CommentAnimeVM>(c))
                    .ToListAsync();
                _cacheService.SetData(key, newData, expire);
                return (newData);
            }

            return (data);
        }

        public async Task<Anime> Post(AnimeVM model)
        {
            string key;
            var data = _mapper.Map<Anime>(model);

            await _context.Animes.AddAsync(data);
            await _context.SaveChangesAsync();

            DateTimeOffset expire = DateTimeOffset.Now.AddMinutes(5);

            key = $"anime{data.ID}";
            _cacheService.SetData(key, data, expire);

            key = $"anime {data.Title}";
            _cacheService.SetData(key, data, expire);

            return (data);
        }

        public async Task<Anime> Put(int animeID, AnimeVM model)
        {
            var data = await _context.Animes.FirstOrDefaultAsync(c => c.ID == animeID);

            string key;
            DateTimeOffset expire = DateTimeOffset.Now.AddMinutes(5);
            key = $"anime{animeID}";
            _cacheService.RemoveData(key);

            key = $"anime {animeID}";
            _cacheService.RemoveData(key);

            _mapper.Map<Anime>(model);
            await _context.SaveChangesAsync();

            key = $"anime{animeID}";
            _cacheService.SetData(key, data, expire);

            key = $"anime {data.Title}";
            _cacheService.SetData(key, data, expire);

            return (data);
        }

        public async Task<Anime> AddEndDate(int animeID, DateOnly date)
        {
            var data = await GetID(animeID);

            data.EndDate = date;

            _context.Animes.Update(data);
            await _context.SaveChangesAsync();

            DateTimeOffset expire = DateTimeOffset.Now.AddMinutes(5);

            string key = $"anime{animeID}";
            _cacheService.SetData(key, data, expire)

            return (anime);
        }

        public async Task<string> Delete(int animeID)
        {
            var anime = await _context.Animes.FirstOrDefaultAsync(a => a.ID == animeID);

            _context.Animes.Remove(anime);
            await _context.SaveChangesAsync();

            return ("Record deleted");
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}