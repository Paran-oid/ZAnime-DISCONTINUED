using Microsoft.EntityFrameworkCore;
using Zanime.Server.Data.Services.Interfaces;
using Zanime.Server.Models.Main;
using Zanime.Server.Models.Main.DTO.Anime_Model;
using Zanime.Server.Models.Main.DTO.Comment_Model;

namespace Zanime.Server.Data.Services
{
    public class AnimeService : IAnimeService
    {
        private readonly ApplicationDbContext _context;

        public AnimeService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<AnimeVM>> GetAll()
        {
            var animes = await _context.Animes
                .Select(a => new AnimeVM
                {
                    Title = a.Title,
                    BackgroundPath = a.BackgroundPath,
                    Description = a.Description,
                    EndDate = a.EndDate,
                    PicturePath = a.PicturePath,
                    Rating = a.Rating,
                    ReleaseDate = a.ReleaseDate
                })
                .ToListAsync();
            return (animes);
        }

        public async Task<Anime> GetID(int animeID)
        {
            var anime = await _context.Animes.FirstOrDefaultAsync(a => a.ID == animeID);

            return (anime);
        }

        public async Task<Anime> GetbyTitle(string title)
        {
            var anime = await _context.Animes.FirstOrDefaultAsync(a => a.Title == title);

            return (anime);
        }

        public async Task<IEnumerable<CommentAnimeVM>> GetComments(int animeID)
        {
            var comments = await _context.Comments
                .Where(c => c.AnimeID == animeID)
                .Select(c => new CommentAnimeVM
                {
                    Username = c.User.UserName,
                    Content = c.Content,
                    Likes = c.Likes
                })
                .ToListAsync();

            return (comments);
        }

        public async Task<Anime> Post(AnimeVM model)
        {
            Anime anime = new Anime
            {
                Title = model.Title,
                ReleaseDate = model.ReleaseDate,
                EndDate = model.EndDate,
                PicturePath = model.PicturePath,
                BackgroundPath = model.BackgroundPath,
                Description = model.Description,
                Rating = model.Rating
            };

            await _context.Animes.AddAsync(anime);
            await _context.SaveChangesAsync();

            return (anime);
        }

        public async Task<Anime> Put(int animeID, AnimeVM model)
        {
            var anime = await _context.Animes.FirstOrDefaultAsync(c => c.ID == animeID);

            anime.Title = model.Title;
            anime.ReleaseDate = model.ReleaseDate;
            anime.EndDate = model.EndDate;
            anime.PicturePath = model.PicturePath;
            anime.BackgroundPath = model.BackgroundPath;
            anime.Description = model.Description;
            anime.Rating = model.Rating;

            _context.Animes.Update(anime);
            await _context.SaveChangesAsync();

            return (anime);
        }

        public async Task<Anime> AddEndDate(int animeID, DateOnly date)
        {
            var anime = await _context.Animes.FirstOrDefaultAsync(a => a.ID == animeID);

            anime.EndDate = date;

            _context.Animes.Update(anime);

            await _context.SaveChangesAsync();

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