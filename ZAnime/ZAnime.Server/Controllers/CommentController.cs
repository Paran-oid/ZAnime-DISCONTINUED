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
                AnimeID = c.AnimeID,
                UserId = c.UserId
            }).ToList();

            return Ok(result);
        }

        [HttpGet("{CommentID}")]
        public async Task<ActionResult<CommentVMDisplay>> Get(int CommentID)
        {
            var comment = await _context.Comments.FirstOrDefaultAsync(c => c.ID == CommentID);
            if (comment == null)
            {
                return NotFound("No comment was found");
            }
            return Ok(comment);
        }

        [HttpGet("{UserID}")]
        public async Task<ActionResult<CommentVM>> ShowUserComments(string UserID)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == UserID);
            if (user == null)
            {
                return NotFound("No user was found");
            }
            var comments = _context.Comments
                .Where(c => c.UserId == UserID)
                .Select(c => new CommentVM
                {
                    Content = c.Content,
                    AnimeID = c.AnimeID
                })
                .ToList();
            return Ok(comments);
        }

        [HttpPost("{UserID}")]
        public async Task<ActionResult<string>> Post(CommentVM model, string UserID)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == UserID);

            if (user == null)
            {
                return NotFound("No user was found");
            }

            var anime = await _context.Animes.FirstOrDefaultAsync(a => a.ID == model.AnimeID);

            if (anime == null)
            {
                return NotFound("No anime was found");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Comment comment = new Comment
            {
                Content = model.Content,
                Likes = 0,
                User = user,
                Anime = anime
            };

            await _context.Comments.AddAsync(comment);
            await _context.SaveChangesAsync();

            return Ok($"{user.UserName} added a comment to {anime.Title}");
        }

        [HttpPut("{CommentID}")]
        public async Task<ActionResult<string>> Put(CommentUpdateVM model, int CommentID)
        {
            var comment = await _context.Comments.FirstOrDefaultAsync(c => c.ID == CommentID);
            if (comment == null)
            {
                return NotFound("No comment was found");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            comment.Content = model.Content;

            await _context.SaveChangesAsync();

            return Ok("comment was modified");
        }

        [HttpPut("{CommentID}")]
        public async Task<ActionResult> LikeComment(int CommentID)
        {
            var comment = await _context.Comments.FirstOrDefaultAsync(c => c.ID == CommentID);
            if (comment == null)
            {
                return NotFound();
            }
            comment.LikeComment();
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPut("{CommentID}")]
        public async Task<ActionResult> DislikeComment(int CommentID)
        {
            var comment = await _context.Comments.FirstOrDefaultAsync(c => c.ID == CommentID);

            if (comment == null)
            {
                return NotFound();
            }

            comment.DislikeComment();
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("{CommentID}")]
        public async Task<ActionResult<string>> Delete(int CommentID)
        {
            var comment = await _context.Comments.FirstOrDefaultAsync(c => c.ID == CommentID);
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