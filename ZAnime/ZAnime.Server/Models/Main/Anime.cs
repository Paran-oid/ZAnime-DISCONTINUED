using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zanime.Server.Models.Main
{
    public class Anime
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public DateOnly ReleaseDate { get; set; }
        public DateOnly? EndDate { get; set; } = null;
        public string Genre { get; set; }
        public string MainPicturePath { get; set; }
        public string BackgroundPath { get; set; }
        public string PicturesPath { get; set; }
        public string Description { get; set; }
        public float Rating { get; set; }

        public List<Character> Characters { get; set; }
        public List<Actor> Actors { get; set; }
        public List<Comment>? Comments { get; set; }
    }
}