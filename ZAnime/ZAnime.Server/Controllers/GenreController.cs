using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Zanime.Server.Data;
using Zanime.Server.Data.Services.Interfaces;
using Zanime.Server.Models.Main;
using Zanime.Server.Models.Main.DTO.Actor_Model;
using Zanime.Server.Models.Main.DTO.Character_Model;
using Zanime.Server.Models.Main.DTO.Genre_Model;

namespace Zanime.Server.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly IGenreService _genreService;

        public GenreController(IGenreService genreService)
        {
            _genreService = genreService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Genre>>> GetAll()
        {
            var genres = await _genreService.GetAll();

            if (genres == null)
            {
                return Ok("No genres available");
            }

            return Ok(genres);
        }

        [HttpGet("{ID}")]
        public async Task<ActionResult<Genre>> Get(int ID)
        {
            var genre = await _genreService.GetID(ID);

            if (genre == null)
            {
                return NotFound("No genre was found");
            }

            return Ok(genre);
        }

        [HttpPost]
        public async Task<ActionResult<Genre>> Post(GenreVM model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (await _genreService.GetbyName(model.Name) != null)
            {
                return Conflict("This genre already exists");
            }

            var response = await _genreService.Post(model);

            return Ok(response);
        }

        [HttpPut("{genreID}")]
        public async Task<ActionResult<GenreVM>> Put(GenreVM model, int genreID)
        {
            var genre = await _genreService.GetID(genreID);

            if (genre == null)
            {
                return NotFound("No genre was found");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _genreService.Put(model, genreID);

            return Ok(response);
        }

        [HttpDelete("{genreID}")]
        public async Task<ActionResult<string>> Delete(int genreID)
        {
            var genre = await _genreService.GetID(genreID);

            if (genre == null)
            {
                return NotFound("No genre was found");
            }

            var response = _genreService.Delete(genre);

            return Ok(response);
        }
    }
}