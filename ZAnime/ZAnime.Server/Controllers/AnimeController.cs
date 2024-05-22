using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Zanime.Server.Data;
using Zanime.Server.Models.Main;
using Zanime.Server.Models.Main.DTO.Anime_Model;

namespace Zanime.Server.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class AnimeController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AnimeController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Anime>>> GetAll()
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
            return Ok(animes);
        }

        [HttpGet("{ID}")]
        public async Task<ActionResult<Anime>> Get(int ID)
        {
            var anime = await _context.Animes.FirstOrDefaultAsync(c => c.ID == ID);
            if (anime == null)
            {
                return NotFound("No anime was found");
            }
            return Ok(anime);
        }

        [HttpPost]
        public async Task<ActionResult<string>> Post(AnimeVM model)
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

            if (await _context.Animes.AnyAsync(a => a.Title == anime.Title))
            {
                return Conflict("Anime with this title already exists");
            }

            await _context.Animes.AddAsync(anime);
            await _context.SaveChangesAsync();

            return Ok($"{anime.Title} was added ");
        }

        [HttpPut("{ID}")]
        public async Task<ActionResult<string>> Put(AnimeVM model, int ID)
        {
            var anime = await _context.Animes.FirstOrDefaultAsync(a => a.ID == ID);
            if (anime == null)
            {
                return NotFound("No anime was found");
            }

            anime.Title = model.Title;
            anime.ReleaseDate = model.ReleaseDate;
            anime.EndDate = model.EndDate;
            anime.PicturePath = model.PicturePath;
            anime.BackgroundPath = model.BackgroundPath;
            anime.Description = model.Description;
            anime.Rating = model.Rating;

            _context.Animes.Update(anime);
            await _context.SaveChangesAsync();

            return Ok("Anime was modified");
        }

        [HttpDelete("{ID}")]
        public async Task<ActionResult<string>> Delete(int ID)
        {
            var anime = await _context.Animes.FirstOrDefaultAsync(a => a.ID == ID);
            if (anime == null)
            {
                return NotFound("No anime was found");
            }
            _context.Animes.Remove(anime);
            await _context.SaveChangesAsync();

            return Ok("Anime was Deleted");
        }
    }
}