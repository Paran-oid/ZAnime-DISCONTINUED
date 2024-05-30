using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Zanime.Server.Data;
using Zanime.Server.Data.Services.Interfaces;
using Zanime.Server.Data.Services.Interfaces.Relationships;
using Zanime.Server.Models.Main;
using Zanime.Server.Models.Main.DTO.Genre_Model;
using Zanime.Server.Models.Main.Relationships;

namespace Zanime.Server.Controllers.Relationship_Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class AnimeGenreController : ControllerBase
    {
        private readonly IAnimeRelationshipsService _animeRelationshipsService;
        private readonly IAnimeService _animeService;
        private readonly IGenreService _genreService;

        public AnimeGenreController(IAnimeRelationshipsService animeRelationshipsService,
                                    IAnimeService animeService,
                                    IGenreService genreService)
        {
            _animeRelationshipsService = animeRelationshipsService;
            _animeService = animeService;
            _genreService = genreService;
        }

        [HttpGet("{animeID}")]
        public async Task<IEnumerable<GenreVM>> GetGenres(int animeID)
        {
            var genres = await _animeRelationshipsService.GetGenres(animeID);

            return (genres);
        }

        [HttpPost("{animeID}")]
        public async Task<ActionResult<string>> CreateGenreToAnime(int animeID, GenreVM model)
        {
            var anime = await _animeService.GetID(animeID);

            if (anime == null)
            {
                return NotFound("No anime found");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _animeRelationshipsService.CreateGenreToAnime(model, animeID);

            return Ok(response);
        }

        [HttpPost("{animeID},{genreID}")]
        public async Task<ActionResult<string>> AddGenreToAnime(int animeID, int genreID)
        {
            var temp = await _animeRelationshipsService.GetRelationshipGenre(animeID, genreID);

            if (temp != null)
            {
                return Conflict("this relationship already exists");
            }

            var anime = await _animeService.GetID(animeID);

            if (anime == null)
            {
                return NotFound("This anime wasn't found");
            }

            var genre = await _genreService.GetByID(genreID);

            if (genre == null)
            {
                return NotFound("This genre wasn't found");
            }

            var response = await _animeRelationshipsService.AddGenreToAnime(animeID, genreID);

            return Ok(response);
        }

        [HttpDelete("{animeID},{genreID}")]
        public async Task<ActionResult> RemoveRelationship(int animeID, int genreID)
        {
            var relationship = await _animeRelationshipsService.GetRelationshipGenre(animeID, genreID);

            if (relationship == null)
            {
                return Conflict("This relationship doesn't exists");
            }

            string response = await _animeRelationshipsService.RemoveRelationshipGenre(relationship);

            return Ok(response);
        }
    }
}