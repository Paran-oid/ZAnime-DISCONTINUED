using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Zanime.Server.Data;
using Zanime.Server.Models.Main;
using Zanime.Server.Models.Main.DTO.Actor_Model;
using Zanime.Server.Models.Main.DTO.Character_Model;
using Zanime.Server.Models.Main.Relationships;

namespace Zanime.Server.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class ActorCharacterController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ActorCharacterController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("{ActorID}")]
        public async Task<ActionResult<List<Character>>> GetCharacters(int ActorID)
        {
            var characters = await _context.ActorCharacters
                .Include(c => c.Character)
                .Where(ac => ac.ActorID == ActorID)
                .Select(ac => new CharacterVM
                {
                    Name = ac.Character.Name,
                    Age = ac.Character.Age,
                    Bio = ac.Character.Bio,
                    Gender = ac.Character.Gender,
                    PicturePath = ac.Character.PicturePath
                })
                .ToListAsync();

            if (characters == null || characters.Count == 0)
            {
                return Ok("No characters for this actor");
            }

            return Ok(characters);
        }

        [HttpGet("{CharacterID}")]
        public async Task<ActionResult<List<Character>>> GetActors(int CharacterID)
        {
            var actors = await _context.ActorCharacters
                .Include(c => c.Actor)
                .Where(ac => ac.CharacterID == CharacterID)
                .Select(ac => new CharacterVM
                {
                    Name = ac.Actor.Name,
                    Age = ac.Actor.Age,
                    Bio = ac.Actor.Bio,
                    Gender = ac.Actor.Gender,
                    PicturePath = ac.Actor.PicturePath
                })
            .ToListAsync();

            if (actors == null || actors.Count == 0)
            {
                return Ok("No actors for this actor");
            }

            return Ok(actors);
        }

        [HttpPost("{CharacterID}")]
        public async Task<ActionResult<string>> CreateActorToCharacter(int CharacterID, ActorVM model)
        {
            var character = await _context.Characters
                .Include(c => c.ActorCharacters)
                .ThenInclude(ac => ac.Actor)
                .FirstOrDefaultAsync(c => c.ID == CharacterID);

            if (character == null)
            {
                return NotFound("No character was found");
            }

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

            await _context.Actors.AddAsync(actor);
            //This is important so we can get the ID
            await _context.SaveChangesAsync();

            ActorCharacter actorCharacter = new ActorCharacter
            {
                ActorID = actor.ID,
                CharacterID = character.ID
            };

            await _context.ActorCharacters.AddAsync(actorCharacter);

            character.ActorCharacters.Add(actorCharacter);

            await _context.SaveChangesAsync();

            return Ok($"{actor.Name} was created for {character.Name}");
        }

        [HttpPost("{ActorID}")]
        public async Task<ActionResult<string>> CreateCharacterToActor(int ActorID, ActorVM model)
        {
            var actor = await _context.Actors
                .Include(c => c.ActorCharacters)
                .ThenInclude(ac => ac.Character)
                .FirstOrDefaultAsync(c => c.ID == ActorID);

            if (actor == null)
            {
                return NotFound("No character was found");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
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
            //This is important so we can get the ID
            await _context.SaveChangesAsync();

            ActorCharacter actorcharacter = new ActorCharacter
            {
                ActorID = actor.ID,
                CharacterID = character.ID
            };

            await _context.ActorCharacters.AddAsync(actorcharacter);
            //This line makes sure the actorcharacter relation was added to the class itself
            actor.ActorCharacters.Add(actorcharacter);
            await _context.SaveChangesAsync();

            return Ok($"{character.Name} was created for {actor.Name}");
        }

        [HttpPost("{ActorID},{CharacterID}")]
        public async Task<ActionResult<string>> AddActorToCharacter(int ActorID, int CharacterID)
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

            ActorCharacter actorCharacter = new ActorCharacter
            {
                ActorID = ActorID,
                CharacterID = character.ID
            };

            _context.ActorCharacters.Add(actorCharacter);
            actor.ActorCharacters.Add(actorCharacter);
            character.ActorCharacters.Add(actorCharacter);

            await _context.SaveChangesAsync();

            return Ok($"{actor.Name} was added to {character.Name}");
        }

        [HttpDelete("{ActorID},{CharacterID}")]
        public async Task<ActionResult> RemoveRelationship(int ActorID, int CharacterID)
        {
            var relationship = await _context.ActorCharacters.FirstOrDefaultAsync(ac => ac.ActorID == ActorID
                                                                                  && ac.CharacterID == CharacterID);

            if (relationship == null)
            {
                return NotFound("No relationship of this kind");
            }

            _context.ActorCharacters.Remove(relationship);
            await _context.SaveChangesAsync();

            return Ok("Relationship deleted successfully");
        }
    }
}