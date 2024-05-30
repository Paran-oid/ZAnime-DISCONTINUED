using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Zanime.Server.Data;
using Zanime.Server.Data.Services.Interfaces;
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
        private readonly IActorRelationshipsService _actorRelationships;
        private readonly IActorService _actorService;
        private readonly ICharacterService _characterService;

        public ActorCharacterController(IActorRelationshipsService actorRelationships,
                                        IActorService actorService,
                                        ICharacterService characterService)
        {
            _actorRelationships = actorRelationships;
            _actorService = actorService;
            _characterService = characterService;
        }

        [HttpGet("{actorID}")]
        public async Task<ActionResult<List<Character>>> GetCharacters(int actorID)
        {
            var characters = await _actorRelationships.GetCharacters(actorID);

            if (characters == null || characters.Count() == 0)
            {
                return Ok("No characters for this actor");
            }

            return Ok(characters);
        }

        [HttpGet("{CharacterID}")]
        public async Task<ActionResult<List<Character>>> GetActors(int CharacterID)
        {
            var actors = await _actorRelationships.GetActors(CharacterID);

            if (actors == null || actors.Count() == 0)
            {
                return Ok("No actors for this actor");
            }

            return Ok(actors);
        }

        [HttpPost("{characterID}")]
        public async Task<ActionResult<string>> CreateActorToCharacter(int characterID, ActorVM model)
        {
            var character = await _actorRelationships.GetCharacterWithActor(characterID);

            if (character == null)
            {
                return NotFound("No character was found");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _actorRelationships.CreateActorToCharacter(character, model);

            return Ok(response);
        }

        [HttpPost("{actorID}")]
        public async Task<ActionResult<string>> CreateCharacterToActor(int actorID, CharacterVM model)
        {
            var actor = await _actorRelationships.GetActorWithCharacter(actorID);

            if (actor == null)
            {
                return NotFound("No character was found");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _actorRelationships.CreateCharacterToActor(actor, model);

            return Ok(response);
        }

        [HttpPost("{actorID},{characterID}")]
        public async Task<ActionResult<string>> AddActorToCharacter(int actorID, int characterID)
        {
            var actor = await _actorService.GetByID(actorID);
            if (actor == null)
            {
                return NotFound("no actor was found");
            }
            var character = await _characterService.GetByID(characterID);
            if (character == null)
            {
                return NotFound("no character was found");
            }

            var response = await _actorRelationships.AddCharacterToActor(actor, character);

            return Ok(response);
        }

        [HttpDelete("{actorID},{characterID}")]
        public async Task<ActionResult> RemoveRelationship(int actorID, int characterID)
        {
            var relationship = await _actorRelationships.GetActorCharacter(actorID, characterID);

            if (relationship == null)
            {
                return NotFound("No relationship of this kind");
            }

            var response = await _actorRelationships.Delete(relationship);

            return Ok(response);
        }
    }
}