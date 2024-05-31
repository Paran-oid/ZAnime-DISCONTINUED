using Zanime.Server.Models.Main;
using Zanime.Server.Models.Core;
using Zanime.Server.Models.Main.DTO.Comment_Model;

namespace Zanime.Server.Data.Services.Interfaces
{
    public interface ICommentService
    {
        public Task<List<Comment>> GetAll();

        public Task<Comment> GetID(int characterID);

        public List<CommentVMDisplay> Display(List<Comment> model);

        public List<CommentVM>? GetUserComments(string userID);

        public Task<CommentVMDisplay> Post(CommentVM model, string userID, int animeID);

        public Task<Comment> Put(CommentUpdateVM model, int commentID);

        public Task<string> Delete(Comment model);

        Task SaveChanges();
    }
}