using System.ComponentModel.DataAnnotations;

namespace Zanime.Server.Models.Main.DTO.Genre_Model
{
    public class GenreVM
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
    }
}