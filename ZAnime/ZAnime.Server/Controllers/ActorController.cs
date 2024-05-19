using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Zanime.Server.Data;
using Zanime.Server.Models.Main;
using Zanime.Server.Models.Main.DTO.Actor_Model;
using Zanime.Server.Models.Main.DTO.Character_Model;

namespace Zanime.Server.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class ActorController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ActorController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Actor>>> GetAll()
        {
            var actors = await _context.Actors.ToListAsync();
            return Ok(actors);
        }

        [HttpGet("{ID}")]
        public async Task<ActionResult<Actor>> Get(int ID)
        {
            var actor = await _context.Actors.FirstOrDefaultAsync(c => c.ID == ID);
            if (actor == null)
            {
                return NotFound("No actor was found");
            }
            return Ok(actor);
        }

        [HttpGet("{ID}")]
        public async Task<ActionResult<List<Actor>>> GetCharacters(int ID)
        {
            var actor = await _context.Actors
                    .Include(a => a.ActorCharacters)
                    .ThenInclude(ac => ac.Character)
                    .FirstOrDefaultAsync(a => a.ID == ID);

            if (actor == null)
            {
                return NotFound("No actor was found");
            }

            if (actor.ActorCharacters.Any())
            {
                var characters = actor.ActorCharacters.Select(ac => new CharacterVM
                {
                    Name = ac.Character.Name,
                    Age = ac.Character.Age,
                    Bio = ac.Character.Bio,
                    Gender = ac.Character.Gender,
                    PicturePath = ac.Character.PicturePath
                }).ToList();

                return Ok(characters);
            }
            return Ok("No characters were found");
        }

        [HttpPost]
        public async Task<ActionResult<string>> Post(ActorVM model)
        {
            Actor actor = new Actor
            {
                Name = model.Name,
                Age = model.Age,
                Gender = model.Gender,
                PicturePath = model.PicturePath,
                Bio = model.Bio,
                Likes = 0,
                Dislikes = 0,
            };

            if (await _context.Actors.AnyAsync(c => c.Name == actor.Name))
            {
                return Conflict("Error");
            }

            await _context.Actors.AddAsync(actor);
            await _context.SaveChangesAsync();

            return Ok($"{actor.Name} was added ");
        }

        [HttpPut("{ID}")]
        public async Task<ActionResult<string>> Put(ActorVM model, int ID)
        {
            var actor = await _context.Actors.FirstOrDefaultAsync(c => c.ID == ID);
            if (actor == null)
            {
                return NotFound("No actor was found");
            }

            actor.Name = model.Name;
            actor.Age = model.Age;
            actor.Gender = model.Gender;
            actor.PicturePath = model.PicturePath;
            actor.Bio = model.Bio;

            await _context.SaveChangesAsync();

            return Ok("actor was modified");
        }

        [HttpDelete("{ID}")]
        public async Task<ActionResult<string>> Delete(int ID)
        {
            var actor = await _context.Actors.FirstOrDefaultAsync(c => c.ID == ID);
            if (actor == null)
            {
                return NotFound("No actor was found");
            }
            _context.Actors.Remove(actor);
            await _context.SaveChangesAsync();

            return Ok("actor was Deleted");
        }
    }
}