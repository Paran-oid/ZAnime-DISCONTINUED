using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Zanime.Server.Data;
using Zanime.Server.Models.Main.Relationships;
using Zanime.Server.Models.Main;
using Microsoft.EntityFrameworkCore;
using Zanime.Server.Models.Main.DTO.Character_Model;
using Zanime.Server.Models.Main.DTO.Actor_Model;
using Zanime.Server.Data.Services.Interfaces.Relationships;
using Zanime.Server.Data.Services.Interfaces;

namespace Zanime.Server.Controllers.Multiple_Interactions
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class AnimeCharacterController : ControllerBase
    {
        private readonly IAnimeRelationshipsService _animeRelationshipsService;
        private readonly IAnimeService _animeService;
        private readonly ICharacterService _characterService;

        public AnimeCharacterController(IAnimeRelationshipsService animeRelationshipsService,
                                        IAnimeService animeService,
                                        ICharacterService characterService)
        {
            _animeRelationshipsService = animeRelationshipsService;
            _animeService = animeService;
            _characterService = characterService;
        }

        [HttpGet("{AnimeID}")]
        public async Task<ActionResult<List<Actor>>> GetCharacters(int AnimeID)
        {
            var characters = await _animeRelationshipsService.GetCharacters(AnimeID);

            if (characters.Count() == 0 || characters == null)
            {
                return Ok("No characters for this anime");
            }

            return Ok(characters);
        }

        [HttpPost("{animeID}")]
        public async Task<ActionResult> CreateCharacterToAnime(int animeID, CharacterVM model)
        {
            var anime = await _animeService.GetID(animeID);
            if (anime == null)
            {
                return NotFound("No anime was found");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            string response = await _animeRelationshipsService.CreateCharacterToAnime(model, animeID);

            return Ok(response);
        }

        [HttpPost("{animeID},{characterID}")]
        public async Task<ActionResult> AddCharacterToAnime(int animeID, int characterID)
        {
            var temp = await _animeRelationshipsService.GetRelationshipCharacter(animeID, characterID);
            if (temp != null)
            {
                return Conflict("This relationship already exists");
            }

            var anime = await _animeService.GetID(animeID);

            if (anime == null)
            {
                return NotFound("No anime was found");
            }

            var character = await _characterService.GetID(characterID);

            if (character == null)
            {
                return NotFound("No character was found");
            }

            string response = await _animeRelationshipsService.AddCharacterToAnime(animeID, characterID);

            return Ok(response);
        }

        [HttpDelete("{animeID},{characterID}")]
        public async Task<ActionResult> RemoveRelationship(int animeID, int characterID)
        {
            var relation = await _animeRelationshipsService.GetRelationshipCharacter(animeID, characterID);

            if (relation == null)
            {
                return NotFound("No relationship of this kind");
            }

            string response = await _animeRelationshipsService.RemoveRelationshipCharacter(relation);

            return Ok(response);
        }
    }
}