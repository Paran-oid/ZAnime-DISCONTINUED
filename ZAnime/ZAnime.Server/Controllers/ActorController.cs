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

        [HttpGet("{ActorID}")]
        public async Task<ActionResult<Actor>> Get(int ActorID)
        {
            var actor = await _context.Actors.FirstOrDefaultAsync(c => c.ID == ActorID);
            if (actor == null)
            {
                return NotFound("No actor was found");
            }
            return Ok(actor);
        }

        [HttpPost]
        public async Task<ActionResult<string>> Post(ActorVM model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
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
                return Conflict("This actor already exists");
            }

            await _context.Actors.AddAsync(actor);
            await _context.SaveChangesAsync();

            return Ok($"{actor.Name} was added ");
        }

        [HttpPut("{ActorID}")]
        public async Task<ActionResult<string>> Put(ActorVM model, int ActorID)
        {
            var actor = await _context.Actors.FirstOrDefaultAsync(c => c.ID == ActorID);
            if (actor == null)
            {
                return NotFound("No actor was found");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            actor.Name = model.Name;
            actor.Age = model.Age;
            actor.Gender = model.Gender;
            actor.PicturePath = model.PicturePath;
            actor.Bio = model.Bio;

            await _context.SaveChangesAsync();

            return Ok("actor was modified");
        }

        [HttpDelete("{ActorID}")]
        public async Task<ActionResult<string>> Delete(int ActorID)
        {
            var actor = await _context.Actors.FirstOrDefaultAsync(c => c.ID == ActorID);
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