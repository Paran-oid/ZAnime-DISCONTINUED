using Elfie.Serialization;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Zanime.Server.Models.Core;
using Zanime.Server.Models.Main;
using Microsoft.AspNetCore;
using System;
using System.Drawing;
using static System.Net.Mime.MediaTypeNames;
using Zanime.Server.Models.Main.DTO.Character_Model;
using Microsoft.AspNetCore.Identity;

namespace Zanime.Server.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>().HasData(
                new User { Id = "1", UserName = "user1@example.com", Fname = "John", Lname = "Doe", ProfilePicturePath = "/images/profile1.jpg" },
                new User { Id = "2", UserName = "user2@example.com", Fname = "Jane", Lname = "Smith", ProfilePicturePath = "/images/profile2.jpg" }
            );

            builder.Entity<Actor>().HasData(
                new Actor { ID = 1, Name = "Tom Hanks", Age = 65, Gender = "Male", PicturePath = "/images/tom_hanks.jpg", Bio = "Tom Hanks is an American actor and filmmaker. He is known for his roles in iconic films such as Forrest Gump, Cast Away, and Saving Private Ryan." },
                new Actor { ID = 2, Name = "Scarlett Johansson", Age = 37, Gender = "Female", PicturePath = "/images/scarlett_johansson.jpg", Bio = "Scarlett Johansson is an American actress and singer. She is known for her roles in films like Lost in Translation, The Avengers, and Marriage Story." }
            );

            builder.Entity<Anime>().HasData(
                new Anime { ID = 1, Title = "Attack on Titan", ReleaseDate = new DateOnly(2013, 4, 7), Genre = "Action, Drama, Fantasy", PicturePath = "/images/attack_on_titan.jpg", Description = "Attack on Titan is a Japanese manga series written and illustrated by Hajime Isayama. It depicts a world where humanity resides within enormous walled cities to protect themselves from the Titans, gigantic humanoid creatures.", BackgroundPath = "none" },
                new Anime { ID = 2, Title = "My Hero Academia", ReleaseDate = new DateOnly(2016, 4, 3), Genre = "Action, Comedy, Superhero", PicturePath = "/images/my_hero_academia.jpg", Description = "My Hero Academia is a Japanese superhero manga series written and illustrated by Kōhei Horikoshi. It follows the story of Izuku Midoriya, a boy born without superpowers in a world where they are the norm, but who still dreams of becoming a superhero himself.", BackgroundPath = "none" }
            );

            builder.Entity<Character>().HasData(
                new Character { ID = 1, Name = "Eren Yeager", Age = 19, Gender = "Male", PicturePath = "/images/eren_yeager.jpg", Bio = "Eren Yeager is the protagonist of Attack on Titan. He joins the military to fight the Titans after his hometown is destroyed and his mother is killed." },
                new Character { ID = 2, Name = "Izuku Midoriya", Age = 16, Gender = "Male", PicturePath = "/images/izuku_midoriya.jpg", Bio = "Izuku Midoriya is the protagonist of My Hero Academia. He is born without a Quirk (superpower) in a world where most people have them, but still aspires to become a hero like his idol, All Might." }
            );

            builder.Entity<Comment>().HasData(
                new Comment { ID = 1, Content = "Great performance by Tom Hanks in Forrest Gump!", Likes = 10, UserId = "1" },
                new Comment { ID = 2, Content = "Attack on Titan is an intense and gripping anime.", Likes = 20, UserId = "2" }
            );

            base.OnModelCreating(builder);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Anime> Animes { get; set; }
        public DbSet<Character> Characters { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}