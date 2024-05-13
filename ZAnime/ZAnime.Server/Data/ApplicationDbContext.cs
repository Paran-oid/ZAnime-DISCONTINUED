using Elfie.Serialization;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
<<<<<<< Updated upstream
using Zanime.Server.Models.Core;
using Zanime.Server.Models.Main;
=======
>>>>>>> Stashed changes
using System;
using System.Drawing;
using Zanime.Server.Models.Core;
using Zanime.Server.Models.Main;
using static System.Net.Mime.MediaTypeNames;
using Zanime.Server.Models.Main.DTO.Character_Model;

namespace Zanime.Server.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Anime> Animes { get; set; }
        public DbSet<Character> Characters { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}