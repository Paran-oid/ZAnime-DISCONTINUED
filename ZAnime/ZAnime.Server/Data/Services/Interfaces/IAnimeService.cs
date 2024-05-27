using Zanime.Server.Models.Main;
using Zanime.Server.Models.Main.DTO.Comment_Model;

namespace Zanime.Server.Data.Services.Interfaces
{
    public interface IAnimeService
    {
        public Task<Anime> GetID(int AnimeID);

        Task SaveChanges();
    }
}