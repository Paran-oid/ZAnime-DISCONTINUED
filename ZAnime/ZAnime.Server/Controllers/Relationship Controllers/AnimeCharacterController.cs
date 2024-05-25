using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Zanime.Server.Data;
using Zanime.Server.Models.Main.Relationships;
using Zanime.Server.Models.Main;
using Microsoft.EntityFrameworkCore;
using Zanime.Server.Models.Main.DTO.Character_Model;
using Zanime.Server.Models.Main.DTO.Actor_Model;

namespace Zanime.Server.Controllers.Multiple_Interactions
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class AnimeCharacterController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AnimeCharacterController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("{AnimeID}")]
        public async Task<ActionResult<List<Actor>>> GetCharacters(int AnimeID)
        {
            var characters = _context.AnimesCharacters
                .Include(ac => ac.Character)
                .Where(ac => ac.AnimeID == AnimeID)
                .Select(ac => new ActorVM
                {
                    Name = ac.Character.Name,
                    Age = ac.Character.Age,
                    Bio = ac.Character.Bio,
                    Gender = ac.Character.Gender,
                    PicturePath = ac.Character.PicturePath
                })
                .ToList();

            if (characters.Count() == 0 || characters == null)
            {
                return Ok("No characters for this anime");
            }

            return Ok(characters);
        }

        [HttpPost("{AnimeID}")]
        public async Task<ActionResult> CreateCharacterToAnime(int AnimeID, CharacterVM model)
        {
            var anime = await _context.Animes.FirstOrDefaultAsync(a => a.ID == AnimeID);
            if (anime == null)
            {
                return NotFound("No anime was found");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var character = new Character
            {
                Name = model.Name,
                Age = model.Age,
                Gender = model.Gender,
                PicturePath = model.PicturePath,
                Bio = model.Bio
            };

            await _context.Characters.AddAsync(character);
            await _context.SaveChangesAsync();

            AnimeCharacter relation = new AnimeCharacter
            {
                CharacterID = character.ID,
                AnimeID = AnimeID,
            };

            await _context.AnimesCharacters.AddAsync(relation);
            await _context.SaveChangesAsync();

            return Ok($"character {character.Name} was added to anime {anime.Title}");
        }

        [HttpPost("{AnimeID},{CharacterID}")]
        public async Task<ActionResult> AddCharacterToAnime(int AnimeID, int CharacterID)
        {
            var temp = await _context.AnimesCharacters.FirstOrDefaultAsync(aa => aa.AnimeID == AnimeID
                                                                           && aa.CharacterID == CharacterID);
            if (temp != null)
            {
                return Conflict("This relationship already exists");
            }

            var anime = await _context.Animes.FirstOrDefaultAsync(a => a.ID == AnimeID);
            if (anime == null)
            {
                return NotFound("No anime was found");
            }
            var character = await _context.Characters.FirstOrDefaultAsync(a => a.ID == CharacterID);
            if (character == null)
            {
                return NotFound("No character was found");
            }

            AnimeCharacter relation = new AnimeCharacter
            {
                CharacterID = CharacterID,
                AnimeID = AnimeID,
            };

            await _context.AnimesCharacters.AddAsync(relation);
            await _context.SaveChangesAsync();

            return Ok($"character {character.Name} was added to anime {anime.Title}");
        }

        [HttpDelete("{AnimeID},{CharacterID}")]
        public async Task<ActionResult> RemoveRelationship(int AnimeID, int CharacterID)
        {
            var relation = await _context.AnimesCharacters.FirstOrDefaultAsync(aa => aa.AnimeID == AnimeID
                                                                               && aa.CharacterID == CharacterID);
            if (relation == null)
            {
                return NotFound("No relationship of this kind");
            }

            _context.AnimesCharacters.Remove(relation);
            await _context.SaveChangesAsync();

            return Ok("Relationship deleted successfully");
        }
    }
}