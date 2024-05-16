using Microsoft.AspNetCore.Identity;
using Zanime.Server.Models.Main;

namespace Zanime.Server.Models.Core
{
    public class User : IdentityUser
    {
        public string? Fname { get; set; }
        public string? Lname { get; set; }
        public string ProfilePicturePath { get; set; }

        public List<Comment>? Comments { get; set; }
    }
}