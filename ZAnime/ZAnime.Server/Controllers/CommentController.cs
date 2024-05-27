using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Zanime.Server.Data;
using Zanime.Server.Data.Services.Interfaces;
using Zanime.Server.Models.Core;
using Zanime.Server.Models.Main;
using Zanime.Server.Models.Main.DTO.Comment_Model;

namespace Zanime.Server.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentService;
        private readonly IAnimeService _animeService;
        private readonly UserManager<User> _usermanager;

        public CommentController(ICommentService commentService, UserManager<User> userManager, IAnimeService animeService)
        {
            _commentService = commentService;
            _animeService = animeService;
            _usermanager = userManager;
        }

        [HttpGet]
        public async Task<ActionResult<List<CommentVMDisplay>>> GetAll()
        {
            var comments = await _commentService.GetAll();

            var response = _commentService.Display(comments);

            return Ok(response);
        }

        [HttpGet("{CommentID}")]
        public async Task<ActionResult<CommentVMDisplay>> Get(int CommentID)
        {
            var comment = await _commentService.GetByID(CommentID);
            if (comment == null)
            {
                return NotFound("No comment was found");
            }
            return Ok(comment);
        }

        [HttpGet("{UserID}")]
        public async Task<ActionResult<CommentVM>> ShowUserComments(string UserID)
        {
            var user = await _usermanager.FindByIdAsync(UserID);

            if (user == null)
            {
                return NotFound("No user was found");
            }

            var comments = _commentService.GetUserComments(UserID);

            return Ok(comments);
        }

        [HttpPost("{UserID}")]
        public async Task<ActionResult<Comment>> Post(CommentVM model, string UserID)
        {
            var user = await _usermanager.FindByIdAsync(UserID);

            if (user == null)
            {
                return NotFound("No user was found");
            }

            var anime = await _animeService.GetID(model.AnimeID);

            if (anime == null)
            {
                return NotFound("No anime was found");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _commentService.Post(model, user, anime);

            return Ok(response);
        }

        [HttpPut("{CommentID}")]
        public async Task<ActionResult<Comment>> Put(CommentUpdateVM model, int CommentID)
        {
            var comment = await _commentService.GetByID(CommentID);
            if (comment == null)
            {
                return NotFound("No comment was found");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _commentService.Put(model, CommentID);

            return Ok(response);
        }

        [HttpPut("{CommentID}")]
        public async Task<ActionResult> LikeComment(int CommentID)
        {
            var comment = await _commentService.GetByID(CommentID);
            if (comment == null)
            {
                return NotFound();
            }
            comment.LikeComment();
            await _commentService.SaveChanges();

            return Ok();
        }

        [HttpPut("{CommentID}")]
        public async Task<ActionResult> DislikeComment(int CommentID)
        {
            var comment = await _commentService.GetByID(CommentID);

            if (comment == null)
            {
                return NotFound();
            }

            comment.DislikeComment();
            await _commentService.SaveChanges();

            return Ok();
        }

        [HttpDelete("{CommentID}")]
        public async Task<ActionResult<string>> Delete(int CommentID)
        {
            var comment = await _commentService.GetByID(CommentID);

            if (comment == null)
            {
                return NotFound("No comment was found");
            }

            var response = await _commentService.Delete(comment);

            return Ok(response);
        }
    }
}