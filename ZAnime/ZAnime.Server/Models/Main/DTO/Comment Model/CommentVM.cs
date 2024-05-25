using System.ComponentModel.DataAnnotations;

namespace Zanime.Server.Models.Main.DTO.Comment_Model
{
    public class CommentVM
    {
        [Required(ErrorMessage = "You need to write something")]
        public string Content { get; set; }

        public int AnimeID { get; set; }
    }
}