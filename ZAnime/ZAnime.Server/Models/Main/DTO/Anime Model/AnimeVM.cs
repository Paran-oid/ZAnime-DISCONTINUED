namespace Zanime.Server.Models.Main.DTO.Anime_Model
{
    public class AnimeVM
    {
        public string Title { get; set; }
        public DateOnly ReleaseDate { get; set; }
        public DateOnly? EndDate { get; set; }
        public string Genre { get; set; }
        public string PicturePath { get; set; }
        public string BackgroundPath { get; set; }
        public string Description { get; set; }
        public float Rating { get; set; }
    }
}