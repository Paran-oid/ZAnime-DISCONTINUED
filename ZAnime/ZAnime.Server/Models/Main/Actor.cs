using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zanime.Server.Models.Main
{
    public class Actor
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string PicturePath { get; set; }
        public string Bio { get; set; }
        public int Likes { get; set; } = 0;
        public int Dislikes { get; set; } = 0;

        //One autor can have many anime characters he voices
        public List<Character> Characters { get; set; }
    }
}