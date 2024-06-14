using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Zanime.Server.Data.Services.Interfaces;
using Zanime.Server.Data.Services.Interfaces.AppRelated;
using Zanime.Server.Models.Main;
using Zanime.Server.Models.Main.DTO.Actor_Model;

namespace Zanime.Server.Data.Services
{
    public class ActorService : IActorService
    {
        private readonly ApplicationDbContext _context;

        private readonly ICacheService _cacheService;
        private readonly IMapper _mapper;

        public ActorService
            (ApplicationDbContext context,
            ICacheService cacheService,
            IMapper mapper
            )
        {
            _context = context;
            _cacheService = cacheService;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Actor>> GetAll()
        {
            string key = "GetAllActors";
            var data = _cacheService.GetData<IEnumerable<Actor>>(key);

            if (data == null)
            {
                DateTimeOffset expire = DateTimeOffset.Now.AddMinutes(5);
                data = await _context.Actors.ToListAsync();

                _cacheService.SetData(key, data, expire);

                return (data);
            }

            return (data);
        }

        public async Task<Actor> GetID(int actorID)
        {
            string key = $"actor{actorID}";
            var data = _cacheService.GetData<Actor>(key);

            if (data == null)
            {
                data = await _context.Actors.FirstOrDefaultAsync(a => a.ID == actorID);
                if (data == null)
                {
                    return default;
                }

                DateTimeOffset expire = DateTime.Now.AddMinutes(5);
                _cacheService.SetData<Actor>(key, data, expire);
                return (data);
            }
            return (data);
        }

        public async Task<Actor> GetbyName(string name)
        {
            string key = $"actor {name}";
            var data = _cacheService.GetData<Actor>(key);

            if (data == null)
            {
                DateTimeOffset expire = DateTimeOffset.Now.AddMinutes(5);
                data = await _context.Actors.FirstOrDefaultAsync(a => a.Name == name);
                _cacheService.SetData<Actor>(key, data, expire);
                return (data);
            }
            return (data);
        }

        public async Task<Actor> Post(ActorVM model)
        {
            Actor actor = _mapper.Map<Actor>(model);

            await _context.Actors.AddAsync(actor);
            await _context.SaveChangesAsync();

            DateTimeOffset expire = DateTimeOffset.Now.AddMinutes(5);

            string key = $"actor{actor.ID}";
            _cacheService.SetData(key, actor, expire);

            key = $"actor {actor.Name}";
            _cacheService.SetData(key, actor, expire);

            _cacheService.RemoveData("GetAllActors");

            return (actor);
        }

        public async Task<Actor> Put(ActorVM model, int ActorID)
        {
            var actor = await _context.Actors.FirstOrDefaultAsync(c => c.ID == ActorID);
            string key;

            DateTimeOffset expire = DateTimeOffset.Now.AddMinutes(5);
            actor = _mapper.Map(model, actor);

            key = $"actor{actor.ID}";
            _cacheService.SetData(key, actor, expire);

            key = $"actor {actor.Name}";
            _cacheService.SetData(key, actor, expire);

            _cacheService.RemoveData("GetAllActors");

            _context.Update(actor);
            await _context.SaveChangesAsync();
            return (actor);
        }

        public async Task<string> Delete(Actor model)
        {
            _context.Actors.Remove(model);
            await _context.SaveChangesAsync();

            string key;

            key = $"actor {model.Name}";
            _cacheService.RemoveData(key);

            key = $"actor{model.ID}";
            _cacheService.RemoveData(key);

            _cacheService.RemoveData("GetAllActors");

            return ("Record Deleted");
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}