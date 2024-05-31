using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Zanime.Server.Data;
using Zanime.Server.Data.Services.Interfaces;
using Zanime.Server.Data.Services.Interfaces.Relationships;
using Zanime.Server.Data.Services.Relationships;
using Zanime.Server.Models.Main;
using Zanime.Server.Models.Main.DTO.Actor_Model;
using Zanime.Server.Models.Main.Relationships;

namespace Zanime.Server.Controllers.Multiple_Interactions
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class AnimeActorController : ControllerBase
    {
        private readonly IAnimeRelationshipsService _animeRelationshipsService;
        private readonly IAnimeService _animeService;
        private readonly IActorService _actorService;

        public AnimeActorController(IAnimeRelationshipsService animeRelationshipsService,
                                    IAnimeService animeService,
                                    IActorService actorService)
        {
            _animeRelationshipsService = animeRelationshipsService;
            _animeService = animeService;
            _actorService = actorService;
        }

        [HttpGet("{AnimeID}")]
        public async Task<ActionResult<List<Actor>>> GetActors(int AnimeID)
        {
            var actors = await _animeRelationshipsService.GetActors(AnimeID);

            if (actors.Count() == 0 || actors == null)
            {
                return Ok("No actors for this anime");
            }

            return Ok(actors);
        }

        [HttpPost("{animeID}")]
        public async Task<ActionResult> CreateActorToAnime(int animeID, ActorVM model)
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

            var response = await _animeRelationshipsService.CreateActorToAnime(model, animeID);

            return Ok(response);
        }

        [HttpPost("{animeID},{actorID}")]
        public async Task<ActionResult> AddActorToAnime(int animeID, int actorID)
        {
            var temp = await _animeRelationshipsService.GetRelationshipActor(animeID, actorID);

            if (temp != null)
            {
                return Conflict("This relationship already exists");
            }

            var anime = await _animeService.GetID(animeID);
            if (anime == null)
            {
                return NotFound("No anime was found");
            }
            var actor = await _actorService.GetID(actorID);

            if (actor == null)
            {
                return NotFound("No actor was found");
            }

            var response = await _animeRelationshipsService.AddActorToAnime(animeID, actorID);

            return Ok(response);
        }

        [HttpDelete("{animeID},{actorID}")]
        public async Task<ActionResult> RemoveRelationship(int animeID, int actorID)
        {
            var relation = await _animeRelationshipsService.GetRelationshipActor(animeID, actorID);
            if (relation == null)
            {
                return NotFound("No relationship of this kind");
            }

            var response = await _animeRelationshipsService.RemoveRelationshipActor(relation);

            return Ok("Relationship deleted successfully");
        }
    }
}