using Microsoft.EntityFrameworkCore;
using Zanime.Server.Data.Services.Interfaces.Relationships;
using Zanime.Server.Models.Main;
using Zanime.Server.Models.Main.DTO.Actor_Model;
using Zanime.Server.Models.Main.DTO.Anime_Model;
using Zanime.Server.Models.Main.DTO.Character_Model;
using Zanime.Server.Models.Main.DTO.Genre_Model;
using Zanime.Server.Models.Main.Relationships;

namespace Zanime.Server.Data.Services.Relationships
{
    public class AnimeRelationshipsService : IAnimeRelationshipsService
    {
        private readonly ApplicationDbContext _context;

        public AnimeRelationshipsService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<AnimeActor> GetRelationshipActor(int animeID, int actorID)
        {
            var relationship = await _context.AnimeActors.FirstOrDefaultAsync(aa => aa.AnimeID == animeID
                                                                               && aa.ActorID == actorID);

            return (relationship);
        }

        public async Task<AnimeCharacter> GetRelationshipCharacter(int animeID, int characterID)
        {
            var relationship = await _context.AnimeCharacters.FirstOrDefaultAsync(aa => aa.AnimeID == animeID
                                                                   && aa.CharacterID == characterID);

            return (relationship);
        }

        public async Task<AnimeGenre> GetRelationshipGenre(int animeID, int genreID)
        {
            var relationship = await _context.AnimeGenres.FirstOrDefaultAsync(aa => aa.AnimeID == animeID
                                                                               && aa.GenreID == genreID);

            return (relationship);
        }

        public async Task<IEnumerable<ActorVM>> GetActors(int animeID)
        {
            var actors = await _context.AnimeActors
                .Include(aa => aa.Actor)
                .Where(aa => aa.AnimeID == animeID)
                .Select(aa => new ActorVM
                {
                    Name = aa.Actor.Name,
                    Age = aa.Actor.Age,
                    Bio = aa.Actor.Bio,
                    Gender = aa.Actor.Gender,
                    PicturePath = aa.Actor.PicturePath
                })
                .ToListAsync();

            return (actors);
        }

        public async Task<IEnumerable<CharacterVM>> GetCharacters(int animeID)
        {
            var characters = await _context.AnimeCharacters
                .Include(aa => aa.Character)
                .Where(aa => aa.AnimeID == animeID)
                .Select(aa => new CharacterVM
                {
                    Name = aa.Character.Name,
                    Age = aa.Character.Age,
                    Bio = aa.Character.Bio,
                    Gender = aa.Character.Gender,
                    PicturePath = aa.Character.PicturePath
                })
                .ToListAsync();

            return (characters);
        }

        public async Task<IEnumerable<GenreVM>> GetGenres(int animeID)
        {
            var genres = await _context.AnimeGenres
                    .Include(aa => aa.Genre)
                    .Where(aa => aa.AnimeID == animeID)
                    .Select(aa => new GenreVM
                    {
                        Name = aa.Genre.Name
                    })
                    .ToListAsync();

            return (genres);
        }

        public async Task<string> CreateActorToAnime(ActorVM model, int animeID)
        {
            var actor = new Actor
            {
                Name = model.Name,
                Age = model.Age,
                Gender = model.Gender,
                PicturePath = model.PicturePath,
                Bio = model.Bio,
            };

            await _context.Actors.AddAsync(actor);
            await _context.SaveChangesAsync();

            AnimeActor relation = new AnimeActor
            {
                ActorID = actor.ID,
                AnimeID = animeID,
            };

            await _context.AnimeActors.AddAsync(relation);
            await _context.SaveChangesAsync();

            string response = "relationship created";

            return (response);
        }

        public async Task<string> CreateCharacterToAnime(CharacterVM model, int animeID)
        {
            var character = new Character
            {
                Name = model.Name,
                Age = model.Age,
                Gender = model.Gender,
                PicturePath = model.PicturePath,
                Bio = model.Bio
            };

            await _context.Characters.AddAsync(character);
            await _context.SaveChangesAsync();

            AnimeCharacter relation = new AnimeCharacter
            {
                CharacterID = character.ID,
                AnimeID = animeID,
            };

            await _context.AnimeCharacters.AddAsync(relation);
            await _context.SaveChangesAsync();

            string response = "relationship created";

            return (response);
        }

        public async Task<string> CreateGenreToAnime(GenreVM model, int animeID)
        {
            Genre genre = new Genre
            {
                Name = model.Name
            };

            await _context.Genres.AddAsync(genre);
            await _context.SaveChangesAsync();

            AnimeGenre relation = new AnimeGenre
            {
                AnimeID = animeID,
                GenreID = genre.ID,
            };

            await _context.AnimeGenres.AddAsync(relation);
            await _context.SaveChangesAsync();

            string response = "relationship created";

            return (response);
        }

        public async Task<string> AddActorToAnime(int animeID, int actorID)
        {
            AnimeActor relation = new AnimeActor
            {
                ActorID = actorID,
                AnimeID = animeID,
            };

            await _context.AnimeActors.AddAsync(relation);
            await _context.SaveChangesAsync();

            string response = "relationship created";

            return (response);
        }

        public async Task<string> AddCharacterToAnime(int animeID, int characterID)
        {
            AnimeCharacter relation = new AnimeCharacter
            {
                CharacterID = characterID,
                AnimeID = animeID,
            };

            await _context.AnimeCharacters.AddAsync(relation);
            await _context.SaveChangesAsync();

            string response = "relationship created";

            return (response);
        }

        public async Task<string> AddGenreToAnime(int animeID, int genreID)
        {
            AnimeGenre relationship = new AnimeGenre
            {
                AnimeID = animeID,
                GenreID = genreID
            };

            await _context.AnimeGenres.AddAsync(relationship);
            await _context.SaveChangesAsync();

            string response = "Relationship created";

            return (response);
        }

        public async Task<string> RemoveRelationshipActor(AnimeActor relationship)
        {
            _context.AnimeActors.Remove(relationship);
            await _context.SaveChangesAsync();

            string response = "Record deleted";

            return (response);
        }

        public async Task<string> RemoveRelationshipCharacter(AnimeCharacter relationship)
        {
            _context.AnimeCharacters.Remove(relationship);
            await _context.SaveChangesAsync();

            string response = "Record deleted";

            return (response);
        }

        public async Task<string> RemoveRelationshipGenre(AnimeGenre relationship)
        {
            _context.AnimeGenres.Remove(relationship);
            await _context.SaveChangesAsync();

            string response = "Record deleted";

            return (response);
        }
    }
}