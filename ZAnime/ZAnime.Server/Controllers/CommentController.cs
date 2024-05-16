using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Zanime.Server.Data;
using Zanime.Server.Models.Core;
using Zanime.Server.Models.Main;
using Zanime.Server.Models.Main.DTO.Comment_Model;

namespace Zanime.Server.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _usermanager;

        public CommentController(ApplicationDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _usermanager = userManager;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CommentVMDisplay>>> GetAll()
        {
            var comments = await _context.Comments.ToListAsync();

            var result = comments.Select(c => new CommentVMDisplay
            {
                ID = c.ID,
                Content = c.Content,
                Likes = c.Likes,
                UserId = c.UserId
            }).ToList();

            return Ok(result);
        }

        [HttpGet("{ID}")]
        public async Task<ActionResult<CommentVMDisplay>> Get(int ID)
        {
            var comment = await _context.Comments.FirstOrDefaultAsync(c => c.ID == ID);
            if (comment == null)
            {
                return NotFound("No comment was found");
            }
            return Ok(comment);
        }

        [HttpGet("{ID}")]
        public async Task<ActionResult<CommentVM>> ShowUserComments(string ID)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == ID);
            if (user == null)
            {
                return NotFound("No user was found");
            }
            var comments = _context.Comments
                .Where(c => c.UserId == ID)
                .Select(c => new CommentVM
                {
                    Content = c.Content
                })
                .ToList();
            return Ok(comments);
        }

        [HttpPost("{ID}")]
        public async Task<ActionResult<string>> Post(CommentVM model, string ID)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == ID);

            if (user == null)
            {
                return NotFound("No user was found");
            }

            Comment comment = new Comment
            {
                Content = model.Content,
                Likes = 0,
                User = user
            };

            await _context.Comments.AddAsync(comment);
            await _context.SaveChangesAsync();

            return Ok($"{user.UserName} added a comment");
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

            await _context.SaveChangesAsync();

            return Ok("comment was modified");
        }

        [HttpPut("{ID}")]
        public async Task<ActionResult> LikeComment(int ID)
        {
            var comment = await _context.Comments.FirstOrDefaultAsync(c => c.ID == ID);
            if (comment == null)
            {
                return NotFound();
            }
            comment.LikeComment();
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPut("{ID}")]
        public async Task<ActionResult> DislikeComment(int ID)
        {
            var comment = await _context.Comments.FirstOrDefaultAsync(c => c.ID == ID);

            if (comment == null)
            {
                return NotFound();
            }

            comment.DislikeComment();
            await _context.SaveChangesAsync();

            return Ok();
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