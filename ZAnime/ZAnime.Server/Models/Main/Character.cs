using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models.Main
{
    public class Character
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string PicturePath { get; set; }
        public string Bio { get; set; }
        public int Likes { get; set; } = 0;
        public int Dislikes { get; set; } = 0;


        //One anime character can have many actors or can even not have one
        public List<Actor>? Actors { get; set; }
    }
}
