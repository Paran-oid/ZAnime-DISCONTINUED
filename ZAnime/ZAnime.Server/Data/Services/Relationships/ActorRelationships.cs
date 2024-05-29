using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Zanime.Server.Data.Services.Interfaces;
using Zanime.Server.Models.Main;
using Zanime.Server.Models.Main.DTO.Actor_Model;
using Zanime.Server.Models.Main.DTO.Character_Model;
using Zanime.Server.Models.Main.Relationships;

namespace Zanime.Server.Data.Services.Relationships
{
    public class ActorRelationships : IActorRelationships
    {
        private readonly ApplicationDbContext _context;

        public ActorRelationships(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ActorCharacter> GetActorCharacter(int actorID, int characterID)
        {
            var relationship = await _context.ActorCharacters.FirstOrDefaultAsync(ac => ac.ActorID == actorID
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
                            .Select(ac => new CharacterVM
                            {
                                Name = ac.Character.Name,
                                Age = ac.Character.Age,
                                Bio = ac.Character.Bio,
                                Gender = ac.Character.Gender,
                                PicturePath = ac.Character.PicturePath
                            })
                            .ToListAsync();

            return (characters);
        }

        public async Task<IEnumerable<ActorVM>> GetActors(int characterID)
        {
            var actors = await _context.ActorCharacters
                             .Include(c => c.Actor)
                             .Where(ac => ac.CharacterID == characterID)
                             .Select(ac => new ActorVM
                             {
                                 Name = ac.Actor.Name,
                                 Age = ac.Actor.Age,
                                 Bio = ac.Actor.Bio,
                                 Gender = ac.Actor.Gender,
                                 PicturePath = ac.Actor.PicturePath
                             })
                         .ToListAsync();

            return (actors);
        }

        public async Task<string> CreateActorToCharacter(Character character, ActorVM model)
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
            Character character = new Character
            {
                Name = model.Name,
                Age = model.Age,
                Gender = model.Gender,
                PicturePath = model.PicturePath,
                Bio = model.Bio,
                Likes = 0,
                Dislikes = 0,
            };

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