using Zanime.Server.Models.Main;
using Zanime.Server.Models.Main.DTO.Anime_Model;
using Zanime.Server.Models.Main.DTO.Genre_Model;

namespace Zanime.Server.Data.Services.Interfaces
{
    public interface IGenreService
    {
        public Task<IEnumerable<Genre>> GetAll();

        public Task<Genre> GetByID(int genreID);

        public Task<Genre> GetByName(string name);

        public Task<Genre> Post(GenreVM model);

        public Task<Genre> Put(GenreVM model, int genreID);

        public Task<string> Delete(Genre model);

        Task SaveChanges();
    }
}