using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shared.Data;
using Zanime.Server.Models.Main;

namespace Zanime.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharacterController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CharacterController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Character>>> GetAll()
        {
            var characters = await _context.Characters.ToListAsync();
            return Ok(characters);
        }
    }
}