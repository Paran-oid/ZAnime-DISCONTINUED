using Zanime.Server.Models.Main.DTO.Actor_Model;
using Zanime.Server.Models.Main.DTO.Character_Model;
using Zanime.Server.Models.Main.DTO.Genre_Model;
using Zanime.Server.Models.Main.Relationships;

namespace Zanime.Server.Data.Services.Interfaces.Relationships
{
    public interface IAnimeRelationshipsService
    {
        public Task<AnimeActor> GetRelationshipActor(int animeID, int actorID);

        public Task<AnimeCharacter> GetRelationshipCharacter(int animeID, int characterID);

        public Task<AnimeGenre> GetRelationshipGenre(int animeID, int genreID);

        public Task<IEnumerable<ActorVM>> GetActors(int animeID);

        public Task<IEnumerable<CharacterVM>> GetCharacters(int animeID);

        public Task<IEnumerable<GenreVM>> GetGenres(int animeID);

        public Task<string> CreateActorToAnime(ActorVM model, int animeID);

        public Task<string> CreateCharacterToAnime(CharacterVM model, int animeID);

        public Task<string> CreateGenreToAnime(GenreVM model, int animeID);

        public Task<string> AddActorToAnime(int animeID, int actorID);

        public Task<string> AddCharacterToAnime(int animeID, int characterID);

        public Task<string> AddGenreToAnime(int animeID, int genreID);

        public Task<string> RemoveRelationshipActor(AnimeActor relationship);

        public Task<string> RemoveRelationshipCharacter(AnimeCharacter relationship);

        public Task<string> RemoveRelationshipGenre(AnimeGenre relationship);
    }
}