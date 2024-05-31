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
    public class ActorController : ControllerBase
    {
        private readonly IActorService _actorService;

        public ActorController(IActorService actorService)
        {
            _actorService = actorService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Actor>>> GetAll()
        {
            var actors = await _actorService.GetAll();
            return Ok(actors);
        }

        [HttpGet("{ActorID}")]
        public async Task<ActionResult<Actor>> Get(int ActorID)
        {
            var actor = await _actorService.GetID(ActorID);

            if (actor == null)
            {
                return NotFound("No actor was found");
            }

            return Ok(actor);
        }

        [HttpPost]
        public async Task<ActionResult<Actor>> Post(ActorVM model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var temp = await _actorService.GetbyName(model.Name);

            if (temp != null)
            {
                return Conflict("This actor already exists");
            }

            await _actorService.Post(model);

            return Ok(model);
        }

        [HttpPut("{ActorID}")]
        public async Task<ActionResult<Actor>> Put(ActorVM model, int ActorID)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _actorService.Put(model, ActorID);

            return Ok(response);
        }

        [HttpDelete("{ActorID}")]
        public async Task<ActionResult<string>> Delete(int ActorID)
        {
            var actor = await _actorService.GetID(ActorID);

            if (actor == null)
            {
                return NotFound("No actor was found");
            }

            var response = await _actorService.Delete(actor);

            return Ok(response);
        }
    }
}