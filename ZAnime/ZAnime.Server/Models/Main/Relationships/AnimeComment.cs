namespace Zanime.Server.Models.Main.Relationships
{
    public class AnimeComment
    {
        public int AnimeID { get; set; }
        public Anime Anime { get; set; }
        public int CommentID { get; set; }
        public Comment Comment { get; set; }
    }
}