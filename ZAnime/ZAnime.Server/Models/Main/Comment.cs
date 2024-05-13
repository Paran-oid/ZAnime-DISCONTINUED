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
        public string Content { get; set; }
        public int Upvotes { get; set; } = 0;
        public int Downvotes { get; set; } = 0;

        public User User { get; set; }
    }
}