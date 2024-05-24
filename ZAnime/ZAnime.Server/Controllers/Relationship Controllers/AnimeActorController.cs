using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Zanime.Server.Data;
using Zanime.Server.Models.Main;
using Zanime.Server.Models.Main.DTO.Actor_Model;
using Zanime.Server.Models.Main.Relationships;

namespace Zanime.Server.Controllers.Multiple_Interactions
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class AnimeActorController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AnimeActorController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("{AnimeID}")]
        public async Task<ActionResult<List<Actor>>> GetActors(int AnimeID)
        {
            var actors = _context.AnimesActors
                .Include(aa => aa.Actor)
                .Where(aa => aa.AnimeID == AnimeID)
                .Select(aa => new ActorVM
                {
                    Name = aa.Actor.Name,
                    Age = aa.Actor.Age,
                    Bio = aa.Actor.Bio,
                    Gender = aa.Actor.Gender,
                    PicturePath = aa.Actor.PicturePath
                })
                .ToList();

            if (actors.Count() == 0 || actors == null)
            {
                return Ok("No actors for this anime");
            }

            return Ok(actors);
        }

        [HttpPost("{AnimeID}")]
        public async Task<ActionResult> CreateActorToAnime(int AnimeID, ActorVM model)
        {
            var anime = await _context.Animes.FirstOrDefaultAsync(a => a.ID == AnimeID);
            if (anime == null)
            {
                return NotFound("No anime was found");
            }

            var actor = new Actor
            {
                Name = model.Name,
                Age = model.Age,
                Gender = model.Gender,
                PicturePath = model.PicturePath,
                Bio = model.Bio,
            };

            await _context.Actors.AddAsync(actor);
            await _context.SaveChangesAsync();

            AnimeActor relation = new AnimeActor
            {
                ActorID = actor.ID,
                AnimeID = AnimeID,
            };

            await _context.AnimesActors.AddAsync(relation);
            await _context.SaveChangesAsync();

            return Ok($"actor {actor.ID} was added to anime {anime.ID}");
        }

        [HttpPost("{AnimeID},{ActorID}")]
        public async Task<ActionResult> AddActorToAnime(int AnimeID, int ActorID)
        {
            var temp = await _context.AnimesActors.FirstOrDefaultAsync(aa => aa.AnimeID == AnimeID
                                                               && aa.ActorID == ActorID);

            if (temp != null)
            {
                return Conflict("This relationship already exists");
            }

            var anime = await _context.Animes.FirstOrDefaultAsync(a => a.ID == AnimeID);
            if (anime == null)
            {
                return NotFound("No anime was found");
            }
            var actor = await _context.Actors.FirstOrDefaultAsync(a => a.ID == ActorID);
            if (actor == null)
            {
                return NotFound("No actor was found");
            }

            AnimeActor relation = new AnimeActor
            {
                ActorID = ActorID,
                AnimeID = AnimeID,
            };

            await _context.AnimesActors.AddAsync(relation);
            await _context.SaveChangesAsync();

            return Ok($"actor {ActorID} was added to anime {AnimeID}");
        }

        [HttpDelete("{AnimeID},{ActorID}")]
        public async Task<ActionResult> RemoveRelationship(int AnimeID, int ActorID)
        {
            var relation = await _context.AnimesActors.FirstOrDefaultAsync(aa => aa.AnimeID == AnimeID
                                                                           && aa.ActorID == ActorID);
            if (relation == null)
            {
                return NotFound("No relationship of this kind");
            }

            _context.AnimesActors.Remove(relation);
            await _context.SaveChangesAsync();

            return Ok("Relationship deleted successfully");
        }
    }
}