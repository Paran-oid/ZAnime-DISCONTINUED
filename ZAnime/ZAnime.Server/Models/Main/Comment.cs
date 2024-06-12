using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Zanime.Server.Models.Core;
using Zanime.Server.Models.Main.Relationships;

namespace Zanime.Server.Models.Main
{
    [Table("Comments", Schema = "anm")]
    public class Comment
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "You need to write something")]
        public string Content { get; set; }

        public int Likes { get; set; } = 0;

        public int AnimeID { get; set; }

        public Anime Anime { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }

        public void LikeComment()
        {
            Likes++;
        }

        public void DislikeComment()
        {
            Likes--;
        }
    }
}