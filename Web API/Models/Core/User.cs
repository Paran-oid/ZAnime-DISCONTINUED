using Microsoft.AspNetCore.Identity;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.General;
using Shared.Models.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models.Core
{
    public class User : IdentityUser
    {
        public string? Fname { get; set; }
        public string? Lname { get; set; }
        public string ProfilePicturePath { get; set; }

        public List<Comment>? Comments { get; set; }
    }
}
