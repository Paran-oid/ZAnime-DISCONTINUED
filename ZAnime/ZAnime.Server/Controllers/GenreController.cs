using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Zanime.Server.Data;
using Zanime.Server.Models.Main;
using Zanime.Server.Models.Main.DTO.Actor_Model;
using Zanime.Server.Models.Main.DTO.Character_Model;
using Zanime.Server.Models.Main.DTO.Genre_Model;

namespace Zanime.Server.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public GenreController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Genre>>> GetAll()
        {
            var genres = await _context.Genres.ToListAsync();

            if (genres == null)
            {
                return Ok("No genres available");
            }

            return Ok(genres);
        }

        [HttpGet("{ID}")]
        public async Task<ActionResult<Genre>> Get(int ID)
        {
            var genre = await _context.Genres.FirstOrDefaultAsync(c => c.ID == ID);
            if (genre == null)
            {
                return NotFound("No genre was found");
            }
            return Ok(genre);
        }

        [HttpPost]
        public async Task<ActionResult<string>> Post(GenreVM model)
        {
            Genre genre = new Genre
            {
                Name = model.Name
            };

            if (await _context.Genres.AnyAsync(c => c.Name == genre.Name))
            {
                return Conflict("This genre already exists");
            }

            await _context.Genres.AddAsync(genre);
            await _context.SaveChangesAsync();

            return Ok($"{genre.Name} was added ");
        }

        [HttpPut("{ID}")]
        public async Task<ActionResult<string>> Put(GenreVM model, int ID)
        {
            var genre = await _context.Genres.FirstOrDefaultAsync(c => c.ID == ID);
            if (genre == null)
            {
                return NotFound("No genre was found");
            }

            genre.Name = model.Name;

            await _context.SaveChangesAsync();

            return Ok("genre was modified");
        }

        [HttpDelete("{ID}")]
        public async Task<ActionResult<string>> Delete(int ID)
        {
            var genre = await _context.Genres.FirstOrDefaultAsync(c => c.ID == ID);
            if (genre == null)
            {
                return NotFound("No genre was found");
            }
            _context.Genres.Remove(genre);
            await _context.SaveChangesAsync();

            return Ok("genre was Deleted");
        }
    }
}