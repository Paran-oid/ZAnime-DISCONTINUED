using System.ComponentModel.DataAnnotations;

using Zanime.Server.Utilities.Attributes;

namespace Zanime.Server.Models.Main.DTO.Anime_Model
{
    public class AnimeVM
    {
        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }

        [Required(ErrorMessage = "ReleaseDate is required")]
        public DateOnly ReleaseDate { get; set; }

        [DateValidationAnime]
        public DateOnly? EndDate { get; set; } = null;

        [Required(ErrorMessage = "PicturePath is required")]
        [PathValidation<AnimeVM>]
        public string PicturePath { get; set; }

        [Required(ErrorMessage = "Title is required")]
        public string BackgroundPath { get; set; }

        [Required(ErrorMessage = "Title is required")]
        public string Description { get; set; }

        [Range(0, 5, ErrorMessage = "Rating must be between 0 and 5")]
        public double Rating { get; set; }
    }
}