namespace Zanime.Server.Models.Main
{
    public class Anime
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public DateOnly ReleaseDate { get; set; }
        public DateOnly? EndDate { get; set; } = null;
        public string Genre { get; set; }
        public string PicturePath { get; set; }
        public string BackgroundPath { get; set; }
        public string Description { get; set; }
        public float Rating { get; set; }

        //MAKE MM RELATIONSHIP WITH ALL OF THESE DOWN BELOW WITH A FOLDER SPECIFICALLY FOR THEM AND ACTOR CHARACTER AND CHANGE THEIR NAMESPACES !!!
        //QUICK TESTT
        public List<Character> Characters { get; set; }

        public List<Actor> Actors { get; set; }
        public List<Comment>? Comments { get; set; }
    }
}