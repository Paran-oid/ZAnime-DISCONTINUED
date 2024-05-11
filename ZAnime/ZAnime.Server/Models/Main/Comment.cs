using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zanime.Server.Models.Core;

namespace Zanime.Server.Models.Main
{
    public class Comment
    {
        public int ID { get; set; }

        //This will be referenced from the user's profile picture
        public string ProfilePicturePath { get; set; }

        //This will be referenced from the user's username
        public string Username { get; set; }

        public string Content { get; set; }
        public int Upvotes { get; set; }
        public int Downvotes { get; set; }

        public User User { get; set; }
    }
}