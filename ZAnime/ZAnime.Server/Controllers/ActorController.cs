using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Zanime.Server.Data;
using Zanime.Server.Models.Main;
using Microsoft.EntityFrameworkCore;
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
                .Include(c => c.Characters)
                .FirstOrDefaultAsync(c => c.ID == ID);

            List<CharacterVM> characters = actor.Characters.Select(a => new CharacterVM
            {
                Name = a.Name,
                Age = a.Age,
                Gender = a.Gender,
                PicturePath = a.PicturePath,
                Bio = a.Bio,
            }).ToList();

            return Ok(characters);
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
                Characters = null
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

            _context.Actors.Update(actor);
            await _context.SaveChangesAsync();

            return Ok("actor was modified");
        }

        [HttpPut("{ActorID},{CharacterID}")]
        public async Task<ActionResult<string>> AddCharacterToActor(int ActorID, int CharacterID)
        {
            var actor = await _context.Actors.FirstOrDefaultAsync(a => a.ID == ActorID);
            if (actor == null)
            {
                return NotFound("no actor was found");
            }
            var character = await _context.Characters.FirstOrDefaultAsync(c => c.ID == CharacterID);
            if (character == null)
            {
                return NotFound("no character was found");
            }
            actor.Characters.Add(character);

            _context.Actors.Update(actor);
            await _context.SaveChangesAsync();

            return Ok($"{character.Name} was added to {actor.Name}");
        }

        [HttpPut("{ID}")]
        public async Task<ActionResult<string>> CreateCharacterToActor(int ID, ActorVM model)
        {
            var actor = await _context.Actors
                .Include(c => c.Characters)
                .FirstOrDefaultAsync(c => c.ID == ID);

            if (actor == null)
            {
                return NotFound("No character was found");
            }

            Character character = new Character
            {
                Name = model.Name,
                Age = model.Age,
                Gender = model.Gender,
                PicturePath = model.PicturePath,
                Bio = model.Bio,
                Likes = 0,
                Dislikes = 0,
            };

            await _context.Characters.AddAsync(character);
            actor.Characters.Add(character);
            _context.Actors.Update(actor);
            await _context.SaveChangesAsync();

            return Ok($"{character.Name} was created for {actor.Name}");
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