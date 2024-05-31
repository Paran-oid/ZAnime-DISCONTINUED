using Zanime.Server.Models.Main;
using Zanime.Server.Models.Main.DTO.Actor_Model;

namespace Zanime.Server.Data.Services.Interfaces
{
    public interface IActorService
    {
        Task<IEnumerable<Actor>> GetAll();

        Task<Actor> GetID(int actorID);

        Task<Actor> GetbyName(string name);

        Task<Actor> Post(ActorVM model);

        Task<Actor> Put(ActorVM model, int ActorID);

        Task<string> Delete(Actor model);

        Task SaveChanges();
    }
}