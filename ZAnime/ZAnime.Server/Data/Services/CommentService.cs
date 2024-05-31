using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;
using Zanime.Server.Data.Services.Interfaces;
using Zanime.Server.Models.Core;
using Zanime.Server.Models.Main;
using Zanime.Server.Models.Main.DTO.Anime_Model;
using Zanime.Server.Models.Main.DTO.Comment_Model;
using Zanime.Server.Models.Main.DTO.Genre_Model;

namespace Zanime.Server.Data.Services
{
    public class CommentService : ICommentService
    {
        private readonly ApplicationDbContext _context;

        public CommentService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Comment>> GetAll()
        {
            var comments = await _context.Comments.ToListAsync();
            return (comments);
        }

        public async Task<Comment> GetID(int commentID)
        {
            var comment = await _context.Comments.FirstOrDefaultAsync(c => c.ID == commentID);
            return (comment);
        }

        public List<CommentVMDisplay> Display(List<Comment> model)
        {
            var comments = model.Select(c => new CommentVMDisplay
            {
                ID = c.ID,
                Content = c.Content,
                Likes = c.Likes,
                AnimeID = c.AnimeID,
                UserId = c.UserId
            }).ToList();

            return (comments);
        }

        public List<CommentVM>? GetUserComments(string userID)
        {
            var comments = _context.Comments
                .Where(c => c.UserId == userID)
                .Select(c => new CommentVM
                {
                    Content = c.Content,
                    AnimeID = c.AnimeID
                })
                .ToList();

            return (comments);
        }

        public async Task<CommentVMDisplay> Post(CommentVM model, string userID, int animeID)
        {
            Comment comment = new Comment
            {
                Content = model.Content,
                UserId = userID,
                AnimeID = animeID
            };

            await _context.Comments.AddAsync(comment);
            await _context.SaveChangesAsync();

            var response = new CommentVMDisplay
            {
                Content = comment.Content,
                Likes = comment.Likes,
                ID = comment.ID,
                UserId = userID,
                AnimeID = animeID,
            };

            return (response);
        }

        public async Task<Comment> Put(CommentUpdateVM model, int commentID)
        {
            var comment = await _context.Comments.FirstOrDefaultAsync(c => c.ID == commentID);

            comment.Content = model.Content;

            await _context.SaveChangesAsync();

            return (comment);
        }

        public async Task<string> Delete(Comment model)
        {
            _context.Comments.Remove(model);
            await _context.SaveChangesAsync();

            return ("Record Deleted");
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}