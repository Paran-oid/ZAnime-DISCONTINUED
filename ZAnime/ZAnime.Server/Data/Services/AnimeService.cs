using Microsoft.EntityFrameworkCore;
using Zanime.Server.Data.Services.Interfaces;
using Zanime.Server.Models.Main;
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

        public async Task<Anime> GetID(int AnimeID)
        {
            var anime = await _context.Animes.FirstOrDefaultAsync(a => a.ID == AnimeID);

            return (anime);
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}