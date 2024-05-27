using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using Zanime.Server.Models.Main;

namespace Zanime.Server.Models.Core
{
    public class User : IdentityUser
    {
        [StringLength(50, ErrorMessage = "First name must contain no more than 50 characters")]
        [RegularExpression(@"^[^\d<>]+$", ErrorMessage = "First name cannot contain numbers or symbols")]
        public string? Fname { get; set; }

        [StringLength(50, ErrorMessage = "Last name must contain no more than 50 characters")]
        [RegularExpression(@"^[^\d<>]+$", ErrorMessage = "First name cannot contain numbers or symbols")]
        public string? Lname { get; set; }

        public string ProfilePicturePath { get; set; }

        public List<Comment>? Comments { get; set; }
    }
}