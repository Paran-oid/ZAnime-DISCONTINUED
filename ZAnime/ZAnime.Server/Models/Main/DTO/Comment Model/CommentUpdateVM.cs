using System.ComponentModel.DataAnnotations;

namespace Zanime.Server.Models.Main.DTO.Comment_Model
{
    public class CommentUpdateVM
    {
        [Required(ErrorMessage = "You need to write something")]
        public string Content { get; set; }
    }
}