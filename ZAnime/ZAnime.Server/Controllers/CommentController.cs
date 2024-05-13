using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Zanime.Server.Data;
using Zanime.Server.Models.Main;
using Microsoft.EntityFrameworkCore;
using Zanime.Server.Models.Main.DTO.Comment_Model;

namespace Zanime.Server.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CommentController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Comment>>> GetAll()
        {
            var comments = await _context.Comments.ToListAsync();
            return Ok(comments);
        }

        [HttpGet("{ID}")]
        public async Task<ActionResult<Comment>> Get(int ID)
        {
            var comment = await _context.Comments.FirstOrDefaultAsync(c => c.ID == ID);
            if (comment == null)
            {
                return NotFound("No comment was found");
            }
            return Ok(comment);
        }

        [HttpPost]
        public async Task<ActionResult<string>> Post(CommentVM model, string Username)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserName == Username);

            if (user == null)
            {
                return NotFound("No user was found");
            }

            Comment comment = new Comment
            {
                Content = model.Content,
                Upvotes = 0,
                Downvotes = 0,
                User = user
            };

            await _context.Comments.AddAsync(comment);
            await _context.SaveChangesAsync();

            return Ok($"{comment.ID} was added by {Username}s ");
        }

        [HttpPut("{ID}")]
        public async Task<ActionResult<string>> Put(CommentVM model, int ID)
        {
            var comment = await _context.Comments.FirstOrDefaultAsync(c => c.ID == ID);
            if (comment == null)
            {
                return NotFound("No comment was found");
            }

            comment.Content = model.Content;

            _context.Comments.Update(comment);
            await _context.SaveChangesAsync();

            return Ok("comment was modified");
        }

        [HttpDelete("{ID}")]
        public async Task<ActionResult<string>> Delete(int ID)
        {
            var comment = await _context.Comments.FirstOrDefaultAsync(c => c.ID == ID);
            if (comment == null)
            {
                return NotFound("No comment was found");
            }
            _context.Comments.Remove(comment);
            await _context.SaveChangesAsync();

            return Ok("comment was Deleted");
        }
    }
}