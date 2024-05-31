using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Zanime.Server.Data;
using Zanime.Server.Data.Services.Interfaces;
using Zanime.Server.Models.Main;
using Zanime.Server.Models.Main.DTO.Actor_Model;
using Zanime.Server.Models.Main.DTO.Character_Model;

namespace Zanime.Server.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class CharacterController : ControllerBase
    {
        private readonly ICharacterService _characterService;

        public CharacterController(ICharacterService characterService)
        {
            _characterService = characterService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Character>>> GetAll()
        {
            var characters = await _characterService.GetAll();
            return Ok(characters);
        }

        [HttpGet("{CharacterID}")]
        public async Task<ActionResult<Character>> Get(int CharacterID)
        {
            var character = await _characterService.GetID(CharacterID);
            if (character == null)
            {
                return NotFound("No character was found");
            }
            return Ok(character);
        }

        [HttpPost]
        public async Task<ActionResult<Character>> Post(CharacterVM model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var temp = await _characterService.GetbyName(model.Name);

            if (temp != null)
            {
                return Conflict("This character already exists");
            }

            var response = await _characterService.Post(model);

            return Ok(response);
        }

        [HttpPut("{CharacterID}")]
        public async Task<ActionResult<Character>> Put(CharacterVM model, int CharacterID)
        {
            var character = await _characterService.GetID(CharacterID);
            if (character == null)
            {
                return NotFound("No character was found");
            }

            var response = await _characterService.Put(model, CharacterID);

            return Ok(response);
        }

        [HttpDelete("{CharacterID}")]
        public async Task<ActionResult<string>> Delete(int CharacterID)
        {
            var character = await _characterService.GetID(CharacterID);
            if (character == null)
            {
                return NotFound("No character was found");
            }

            var response = await _characterService.Delete(character);

            return Ok(response);
        }
    }
}