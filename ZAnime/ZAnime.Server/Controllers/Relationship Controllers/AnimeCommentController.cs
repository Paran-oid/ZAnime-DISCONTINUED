using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Zanime.Server.Data;
using Zanime.Server.Models.Main.Relationships;
using Zanime.Server.Models.Main;
using Microsoft.EntityFrameworkCore;
using Zanime.Server.Models.Main.DTO.Comment_Model;
using System.ComponentModel.Design;

namespace Zanime.Server.Controllers.Multiple_Interactions
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class AnimeCommentController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AnimeCommentController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost("{AnimeID},{CommentID}")]
        public async Task<ActionResult> AddCommentToAnime(int AnimeID, int CommentID)
        {
            var temp = await _context.AnimesComments.FirstOrDefaultAsync(aa => aa.AnimeID == AnimeID
                                                                        && aa.CommentID == CommentID);
            if (temp != null)
            {
                return Conflict("This relationship already exists");
            }

            var anime = await _context.Animes.FirstOrDefaultAsync(a => a.ID == AnimeID);
            if (anime == null)
            {
                return NotFound("No anime was found");
            }
            var comment = await _context.Comments.FirstOrDefaultAsync(a => a.ID == CommentID);
            if (comment == null)
            {
                return NotFound("No comment was found");
            }

            AnimeComment relation = new AnimeComment
            {
                CommentID = CommentID,
                AnimeID = AnimeID,
            };

            await _context.AnimesComments.AddAsync(relation);
            await _context.SaveChangesAsync();

            return Ok($"comment {CommentID} was added to anime {AnimeID}");
        }

        [HttpDelete("{AnimeID},{CommentID}")]
        public async Task<ActionResult> RemoveRelationship(int AnimeID, int CommentID)
        {
            var relation = await _context.AnimesComments.FirstOrDefaultAsync(aa => aa.AnimeID == AnimeID
                                                                           && aa.CommentID == CommentID);
            if (relation == null)
            {
                return NotFound("No relationship of this kind");
            }

            _context.AnimesComments.Remove(relation);
            await _context.SaveChangesAsync();

            return Ok("Relationship deleted successfully");
        }
    }
}