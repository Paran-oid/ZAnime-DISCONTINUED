using Zanime.Server.Models.Main;
using Zanime.Server.Models.Main.DTO.Actor_Model;

namespace Zanime.Server.Data.Services
{
    public interface IActorService
    {
        Task<IEnumerable<Actor>> GetAll();

        Task<Actor> Get(int ActorID);

        Task<Actor> Post(ActorVM model);

        Task<Actor> Put(ActorVM model, int ActorID);

        Task Delete(Actor model);
    }
}