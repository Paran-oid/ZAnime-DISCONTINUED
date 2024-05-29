using Zanime.Server.Models.Main;
using Zanime.Server.Models.Main.DTO.Anime_Model;
using Zanime.Server.Models.Main.DTO.Comment_Model;

namespace Zanime.Server.Data.Services.Interfaces
{
    public interface IAnimeService
    {
        public Task<IEnumerable<AnimeVM>> GetAll();

        public Task<Anime> GetID(int animeID);

        public Task<Anime> GetByTitle(string title);

        public Task<IEnumerable<CommentAnimeVM>> GetComments(int animeID);

        public Task<Anime> Post(AnimeVM model);

        public Task<Anime> Put(int animeID, AnimeVM model);

        public Task<Anime> AddEndDate(int animeID, DateOnly date);

        public Task<string> Delete(int animeID);

        Task SaveChanges();
    }
}