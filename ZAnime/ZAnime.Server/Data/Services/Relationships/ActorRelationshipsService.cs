using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Zanime.Server.Data.Services.Interfaces;
using Zanime.Server.Models.Main;
using Zanime.Server.Models.Main.DTO.Actor_Model;
using Zanime.Server.Models.Main.DTO.Character_Model;
using Zanime.Server.Models.Main.Relationships;

namespace Zanime.Server.Data.Services.Relationships
{
    public class ActorRelationshipsService : IActorRelationshipsService
    {
        private readonly ApplicationDbContext _context;

        private readonly IMapper _mapper;

        public ActorRelationshipsService(
            ApplicationDbContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ActorCharacter> GetActorCharacter(int actorID, int characterID)
        {
            var relationship = await _context.ActorCharacters
                .FirstOrDefaultAsync(ac => ac.ActorID == actorID
                && ac.CharacterID == characterID);

            return (relationship);
        }

        public async Task<Character> GetCharacterWithActor(int characterID)
        {
            var character = await _context.Characters
                .Include(c => c.ActorCharacters)
                .ThenInclude(ac => ac.Actor)
                .FirstOrDefaultAsync(c => c.ID == characterID);

            return (character);
        }

        public async Task<Actor> GetActorWithCharacter(int actorID)
        {
            var actor = await _context.Actors
                .Include(c => c.ActorCharacters)
                .ThenInclude(ac => ac.Character)
                .FirstOrDefaultAsync(c => c.ID == actorID);

            return (actor);
        }

        public async Task<IEnumerable<CharacterVM>> GetCharacters(int actorID)
        {
            var characters = await _context.ActorCharacters
                            .Include(c => c.Character)
                            .Where(ac => ac.ActorID == actorID)
                            .Select(c => _mapper.Map<CharacterVM>(c))
                            .ToListAsync();

            return (characters);
        }

        public async Task<IEnumerable<ActorVM>> GetActors(int characterID)
        {
            var actors = await _context.ActorCharacters
                             .Include(c => c.Actor)
                             .Where(ac => ac.CharacterID == characterID)
                             .Select(c => _mapper.Map<ActorVM>(c))
                         .ToListAsync();

            return (actors);
        }

        public async Task<string> CreateActorToCharacter(Character character, ActorVM model)
        {
            var actor = _mapper.Map<Actor>(model);

            await _context.Actors.AddAsync(actor);
            //This is important so we can get the ID
            await _context.SaveChangesAsync();

            ActorCharacter actorCharacter = new ActorCharacter
            {
                ActorID = actor.ID,
                CharacterID = character.ID
            };

            await _context.ActorCharacters.AddAsync(actorCharacter);

            character.ActorCharacters.Add(actorCharacter);

            await _context.SaveChangesAsync();

            return ("Relationship set");
        }

        public async Task<string> CreateCharacterToActor(Actor actor, CharacterVM model)
        {
            var character = _mapper.Map<Character>(model);

            await _context.Characters.AddAsync(character);
            //This is important so we can get the ID
            await _context.SaveChangesAsync();

            ActorCharacter actorcharacter = new ActorCharacter
            {
                ActorID = actor.ID,
                CharacterID = character.ID
            };

            await _context.ActorCharacters.AddAsync(actorcharacter);
            //This line makes sure the actorcharacter relation was added to the class itself
            actor.ActorCharacters.Add(actorcharacter);
            await _context.SaveChangesAsync();

            return ("Relationship set");
        }

        public async Task<string> AddCharacterToActor(Actor actor, Character character)
        {
            ActorCharacter actorCharacter = new ActorCharacter
            {
                ActorID = actor.ID,
                CharacterID = character.ID
            };

            await _context.ActorCharacters.AddAsync(actorCharacter);
            actor.ActorCharacters.Add(actorCharacter);
            character.ActorCharacters.Add(actorCharacter);
            await _context.SaveChangesAsync();

            return ("Relationship set");
        }

        public async Task<string> Delete(ActorCharacter relationship)
        {
            _context.ActorCharacters.Remove(relationship);
            await _context.SaveChangesAsync();

            return ("Record deleted");
        }
    }
}