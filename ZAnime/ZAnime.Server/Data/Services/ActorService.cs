using Microsoft.EntityFrameworkCore;
using Zanime.Server.Models.Main;
using Zanime.Server.Models.Main.DTO.Actor_Model;

namespace Zanime.Server.Data.Services
{
    public class ActorService : IActorService
    {
        private readonly ApplicationDbContext _context;

        public ActorService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Actor>> GetAll()
        {
            var actors = await _context.Actors.ToListAsync();
            return (actors);
        }

        public async Task<Actor> Get(int ActorID)
        {
            var actor = await _context.Actors.FirstOrDefaultAsync(a => a.ID == ActorID);
            return (actor);
        }

        public async Task<Actor> Post(ActorVM model)
        {
            Actor actor = new Actor
            {
                Name = model.Name,
                Age = model.Age,
                Gender = model.Gender,
                PicturePath = model.PicturePath,
                Bio = model.Bio,
                Likes = 0,
                Dislikes = 0,
            };

            await _context.Actors.AddAsync(actor);
            await _context.SaveChangesAsync();

            return (actor);
        }

        public async Task<Actor> Put(ActorVM model, int ActorID)
        {
            var actor = await _context.Actors.FirstOrDefaultAsync(c => c.ID == ActorID);

            actor.Name = model.Name;
            actor.Age = model.Age;
            actor.Gender = model.Gender;
            actor.PicturePath = model.PicturePath;
            actor.Bio = model.Bio;

            await _context.SaveChangesAsync();

            return (actor);
        }

        public async Task Delete(Actor model)
        {
            _context.Actors.Remove(model);
            await _context.SaveChangesAsync();
        }
    }
}