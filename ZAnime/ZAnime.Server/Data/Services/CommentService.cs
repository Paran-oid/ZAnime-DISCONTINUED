using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;
using Zanime.Server.Data.Services.Interfaces;
using Zanime.Server.Models.Core;
using Zanime.Server.Models.Main;
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

        public async Task<Comment> GetByID(int CommentID)
        {
            var comment = await _context.Comments.FirstOrDefaultAsync(c => c.ID == CommentID);
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

        public List<CommentVM>? GetUserComments(string UserID)
        {
            var comments = _context.Comments
                .Where(c => c.UserId == UserID)
                .Select(c => new CommentVM
                {
                    Content = c.Content,
                    AnimeID = c.AnimeID
                })
                .ToList();

            return (comments);
        }

        public async Task<Comment> Post(CommentVM model, User user, Anime anime)
        {
            Comment comment = new Comment
            {
                Content = model.Content,
                User = user,
                Anime = anime
            };

            await _context.Comments.AddAsync(comment);
            await _context.SaveChangesAsync();

            return (comment);
        }

        public async Task<Comment> Put(CommentUpdateVM model, int CommentID)
        {
            var comment = await _context.Comments.FirstOrDefaultAsync(c => c.ID == CommentID);

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