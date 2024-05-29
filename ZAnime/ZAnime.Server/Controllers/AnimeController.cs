using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Zanime.Server.Data;
using Zanime.Server.Data.Services.Interfaces;
using Zanime.Server.Models.Main;
using Zanime.Server.Models.Main.DTO.Anime_Model;
using Zanime.Server.Models.Main.DTO.Comment_Model;

namespace Zanime.Server.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class AnimeController : ControllerBase
    {
        private readonly IAnimeService _animeService;

        public AnimeController(IAnimeService animeService)
        {
            _animeService = animeService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AnimeVM>>> GetAll()
        {
            var animes = await _animeService.GetAll();
            return Ok(animes);
        }

        [HttpGet("{animeID}")]
        public async Task<ActionResult<Anime>> Get(int animeID)
        {
            var anime = await _animeService.GetID(animeID);

            if (anime == null)
            {
                return NotFound("No anime was found");
            }

            return Ok(anime);
        }

        [HttpGet("{animeID}")]
        public async Task<ActionResult<IEnumerable<Comment>>> GetComments(int animeID)
        {
            var comments = await _animeService.GetComments(animeID);

            if (comments == null)
            {
                return Ok("No comments available");
            }

            return Ok(comments);
        }

        [HttpPost]
        public async Task<ActionResult<Anime>> Post(AnimeVM model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (await _animeService.GetByTitle(model.Title) != null)
            {
                return Conflict("Anime with this title already exists");
            }

            var response = await _animeService.Post(model);

            return (response);
        }

        [HttpPut("{animeID}")]
        public async Task<ActionResult<string>> Put(AnimeVM model, int animeID)
        {
            if (await _animeService.GetID(animeID) == null)
            {
                return NotFound("No anime was found");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _animeService.Put(animeID, model);

            return Ok(response);
        }

        [HttpPut("{animeID}")]
        public async Task<ActionResult<string>> AddEndDate(int animeID, [FromBody] DateOnly endDate)
        {
            var anime = await _animeService.GetID(animeID);

            if (anime == null)
            {
                return NotFound("No anime was found");
            }

            var response = await _animeService.AddEndDate(animeID, endDate);

            return Ok(response);
        }

        [HttpDelete("{animeID}")]
        public async Task<ActionResult<string>> Delete(int animeID)
        {
            var anime = await _animeService.GetID(animeID);

            if (anime == null)
            {
                return NotFound("No anime was found");
            }

            var response = await _animeService.Delete(animeID);

            return Ok(response);
        }
    }
}