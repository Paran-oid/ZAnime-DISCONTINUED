using Zanime.Server.Models.Main;
using Zanime.Server.Models.Core;
using Zanime.Server.Models.Main.DTO.Comment_Model;

namespace Zanime.Server.Data.Services.Interfaces
{
    public interface ICommentService
    {
        public Task<List<Comment>> GetAll();

        public Task<Comment> GetByID(int CharacterID);

        public List<CommentVMDisplay> Display(List<Comment> model);

        public List<CommentVM>? GetUserComments(string UserID);

        public Task<CommentVMDisplay> Post(CommentVM model, string userID, int animeID);

        public Task<Comment> Put(CommentUpdateVM model, int CommentID);

        public Task<string> Delete(Comment model);

        Task SaveChanges();
    }
}