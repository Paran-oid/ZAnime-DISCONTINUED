using Microsoft.EntityFrameworkCore;
using Zanime.Server.Data.Services.Interfaces;
using Zanime.Server.Models.Main;
using Zanime.Server.Models.Main.DTO.Genre_Model;

namespace Zanime.Server.Data.Services
{
    public class GenreService : IGenreService
    {
        private readonly ApplicationDbContext _context;

        public GenreService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Genre>> GetAll()
        {
            var genres = await _context.Genres.ToListAsync();
            return (genres);
        }

        public async Task<Genre> GetID(int genreID)
        {
            var genre = await _context.Genres.FirstOrDefaultAsync(g => g.ID == genreID);
            return (genre);
        }

        public async Task<Genre> GetbyName(string name)
        {
            var genre = await _context.Genres.FirstOrDefaultAsync(g => g.Name == name);
            return (genre);
        }

        public async Task<Genre> Post(GenreVM model)
        {
            Genre genre = new Genre
            {
                Name = model.Name,
            };

            await _context.Genres.AddAsync(genre);
            await _context.SaveChangesAsync();

            return (genre);
        }

        public async Task<Genre> Put(GenreVM model, int genreID)
        {
            var genre = await _context.Genres.FirstOrDefaultAsync(c => c.ID == genreID);

            genre.Name = model.Name;

            await _context.SaveChangesAsync();

            return (genre);
        }

        public async Task<string> Delete(Genre model)
        {
            _context.Genres.Remove(model);
            await _context.SaveChangesAsync();

            return ("Record Deleted");
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}