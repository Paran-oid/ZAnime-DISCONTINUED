using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Zanime.Server.Data;
using Zanime.Server.Models.Main;
using Zanime.Server.Models.Main.DTO.Genre_Model;
using Zanime.Server.Models.Main.Relationships;

namespace Zanime.Server.Controllers.Relationship_Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class AnimeGenreController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AnimeGenreController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost("{AnimeID}")]
        public async Task<ActionResult<string>> CreateGenreToAnime(int AnimeID, GenreVM model)
        {
            var anime = await _context.Animes.FirstOrDefaultAsync(a => a.ID == AnimeID);
            if (anime == null)
            {
                return NotFound("No anime found");
            }

            Genre genre = new Genre
            {
                Name = model.Name
            };

            await _context.Genres.AddAsync(genre);
            await _context.SaveChangesAsync();

            AnimeGenre relation = new AnimeGenre
            {
                AnimeID = AnimeID,
                GenreID = genre.ID,
            };

            await _context.AnimesGenres.AddAsync(relation);
            await _context.SaveChangesAsync();

            return Ok($"genre {genre.ID} was added to anime {AnimeID}");
        }

        [HttpPost("{AnimeID},{GenreID}")]
        public async Task<ActionResult<string>> AddGenreToAnime(int AnimeID, int GenreID)
        {
            var temp = await _context.AnimesGenres.AnyAsync(ag => ag.AnimeID == AnimeID
                                                           && ag.GenreID == GenreID);
            if (temp)
            {
                return Conflict("this relationship already exists");
            }

            var anime = await _context.Animes.AnyAsync(a => a.ID == AnimeID);

            if (!anime)
            {
                return NotFound("This anime wasn't found");
            }

            var genre = await _context.Genres.AnyAsync(g => g.ID == GenreID);

            if (!genre)
            {
                return NotFound("This genre wasn't found");
            }

            AnimeGenre relationship = new AnimeGenre
            {
                AnimeID = AnimeID,
                GenreID = GenreID
            };

            await _context.AnimesGenres.AddAsync(relationship);
            await _context.SaveChangesAsync();

            return Ok($"genre {GenreID} was added to anime {AnimeID}");
        }

        [HttpDelete("{AnimeID},{GenreID}")]
        public async Task<ActionResult> RemoveRelationship(int AnimeID, int GenreID)
        {
            var relationship = await _context.AnimesGenres.FirstOrDefaultAsync(aa => aa.AnimeID == AnimeID
                                                   && aa.GenreID == GenreID);

            if (relationship == null)
            {
                return Conflict("This relationship doesn't exists");
            }

            _context.AnimesGenres.Remove(relationship);
            await _context.SaveChangesAsync();

            return Ok("Relationship deleted successfully");
        }
    }
}