﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Zanime.Server.Data;

#nullable disable

namespace Zanime.Server.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240522101111_Anime Genre relationship")]
    partial class AnimeGenrerelationship
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Zanime.Server.Models.Core.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("Fname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Lname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("ProfilePicturePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "1",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "b6bd8759-58c0-47fb-abd5-a0f5a5784f6d",
                            EmailConfirmed = false,
                            Fname = "John",
                            Lname = "Doe",
                            LockoutEnabled = false,
                            PhoneNumberConfirmed = false,
                            ProfilePicturePath = "/images/profile1.jpg",
                            SecurityStamp = "7e7fafdc-c3f0-4219-8ffd-489e69929378",
                            TwoFactorEnabled = false,
                            UserName = "user1@example.com"
                        },
                        new
                        {
                            Id = "2",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "d6b2f1e3-e1f0-433f-96c3-7d93ce11b32e",
                            EmailConfirmed = false,
                            Fname = "Jane",
                            Lname = "Smith",
                            LockoutEnabled = false,
                            PhoneNumberConfirmed = false,
                            ProfilePicturePath = "/images/profile2.jpg",
                            SecurityStamp = "c1bb81f1-f667-4415-aa53-5486366550a2",
                            TwoFactorEnabled = false,
                            UserName = "user2@example.com"
                        });
                });

            modelBuilder.Entity("Zanime.Server.Models.Main.Actor", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Bio")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Dislikes")
                        .HasColumnType("int");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Likes")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PicturePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Actors");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Age = 65,
                            Bio = "Tom Hanks is an American actor and filmmaker. He is known for his roles in iconic films such as Forrest Gump, Cast Away, and Saving Private Ryan.",
                            Dislikes = 0,
                            Gender = "Male",
                            Likes = 0,
                            Name = "Tom Hanks",
                            PicturePath = "/images/tom_hanks.jpg"
                        },
                        new
                        {
                            ID = 2,
                            Age = 37,
                            Bio = "Scarlett Johansson is an American actress and singer. She is known for her roles in films like Lost in Translation, The Avengers, and Marriage Story.",
                            Dislikes = 0,
                            Gender = "Female",
                            Likes = 0,
                            Name = "Scarlett Johansson",
                            PicturePath = "/images/scarlett_johansson.jpg"
                        });
                });

            modelBuilder.Entity("Zanime.Server.Models.Main.Anime", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("BackgroundPath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateOnly?>("EndDate")
                        .HasColumnType("date");

                    b.Property<string>("PicturePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Rating")
                        .HasColumnType("real");

                    b.Property<DateOnly>("ReleaseDate")
                        .HasColumnType("date");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Animes");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            BackgroundPath = "none",
                            Description = "Attack on Titan is a Japanese manga series written and illustrated by Hajime Isayama. It depicts a world where humanity resides within enormous walled cities to protect themselves from the Titans, gigantic humanoid creatures.",
                            PicturePath = "/images/attack_on_titan.jpg",
                            Rating = 0f,
                            ReleaseDate = new DateOnly(2013, 4, 7),
                            Title = "Attack on Titan"
                        },
                        new
                        {
                            ID = 2,
                            BackgroundPath = "none",
                            Description = "My Hero Academia is a Japanese superhero manga series written and illustrated by Kōhei Horikoshi. It follows the story of Izuku Midoriya, a boy born without superpowers in a world where they are the norm, but who still dreams of becoming a superhero himself.",
                            PicturePath = "/images/my_hero_academia.jpg",
                            Rating = 0f,
                            ReleaseDate = new DateOnly(2016, 4, 3),
                            Title = "My Hero Academia"
                        });
                });

            modelBuilder.Entity("Zanime.Server.Models.Main.Character", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Bio")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Dislikes")
                        .HasColumnType("int");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Likes")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PicturePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Characters");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Age = 19,
                            Bio = "Eren Yeager is the protagonist of Attack on Titan. He joins the military to fight the Titans after his hometown is destroyed and his mother is killed.",
                            Dislikes = 0,
                            Gender = "Male",
                            Likes = 0,
                            Name = "Eren Yeager",
                            PicturePath = "/images/eren_yeager.jpg"
                        },
                        new
                        {
                            ID = 2,
                            Age = 16,
                            Bio = "Izuku Midoriya is the protagonist of My Hero Academia. He is born without a Quirk (superpower) in a world where most people have them, but still aspires to become a hero like his idol, All Might.",
                            Dislikes = 0,
                            Gender = "Male",
                            Likes = 0,
                            Name = "Izuku Midoriya",
                            PicturePath = "/images/izuku_midoriya.jpg"
                        });
                });

            modelBuilder.Entity("Zanime.Server.Models.Main.Comment", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Likes")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ID");

                    b.HasIndex("UserId");

                    b.ToTable("Comments");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Content = "Great performance by Tom Hanks in Forrest Gump!",
                            Likes = 10,
                            UserId = "1"
                        },
                        new
                        {
                            ID = 2,
                            Content = "Attack on Titan is an intense and gripping anime.",
                            Likes = 20,
                            UserId = "2"
                        });
                });

            modelBuilder.Entity("Zanime.Server.Models.Main.Genre", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Genres");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Name = "Action"
                        },
                        new
                        {
                            ID = 2,
                            Name = "Horror"
                        });
                });

            modelBuilder.Entity("Zanime.Server.Models.Main.Relationships.ActorCharacter", b =>
                {
                    b.Property<int>("ActorID")
                        .HasColumnType("int");

                    b.Property<int>("CharacterID")
                        .HasColumnType("int");

                    b.HasKey("ActorID", "CharacterID");

                    b.HasIndex("CharacterID");

                    b.ToTable("ActorCharacters");
                });

            modelBuilder.Entity("Zanime.Server.Models.Main.Relationships.AnimeActor", b =>
                {
                    b.Property<int>("ActorID")
                        .HasColumnType("int");

                    b.Property<int>("AnimeID")
                        .HasColumnType("int");

                    b.HasKey("ActorID", "AnimeID");

                    b.HasIndex("AnimeID");

                    b.ToTable("AnimesActors");
                });

            modelBuilder.Entity("Zanime.Server.Models.Main.Relationships.AnimeCharacter", b =>
                {
                    b.Property<int>("CharacterID")
                        .HasColumnType("int");

                    b.Property<int>("AnimeID")
                        .HasColumnType("int");

                    b.HasKey("CharacterID", "AnimeID");

                    b.HasIndex("AnimeID");

                    b.ToTable("AnimesCharacters");
                });

            modelBuilder.Entity("Zanime.Server.Models.Main.Relationships.AnimeComment", b =>
                {
                    b.Property<int>("CommentID")
                        .HasColumnType("int");

                    b.Property<int>("AnimeID")
                        .HasColumnType("int");

                    b.HasKey("CommentID", "AnimeID");

                    b.HasIndex("AnimeID");

                    b.ToTable("AnimesComments");
                });

            modelBuilder.Entity("Zanime.Server.Models.Main.Relationships.AnimeGenre", b =>
                {
                    b.Property<int>("GenreID")
                        .HasColumnType("int");

                    b.Property<int>("AnimeID")
                        .HasColumnType("int");

                    b.HasKey("GenreID", "AnimeID");

                    b.HasIndex("AnimeID");

                    b.ToTable("AnimesGenres");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Zanime.Server.Models.Core.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Zanime.Server.Models.Core.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Zanime.Server.Models.Core.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Zanime.Server.Models.Core.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Zanime.Server.Models.Main.Comment", b =>
                {
                    b.HasOne("Zanime.Server.Models.Core.User", "User")
                        .WithMany("Comments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Zanime.Server.Models.Main.Relationships.ActorCharacter", b =>
                {
                    b.HasOne("Zanime.Server.Models.Main.Actor", "Actor")
                        .WithMany("ActorCharacters")
                        .HasForeignKey("ActorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Zanime.Server.Models.Main.Character", "Character")
                        .WithMany("ActorCharacters")
                        .HasForeignKey("CharacterID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Actor");

                    b.Navigation("Character");
                });

            modelBuilder.Entity("Zanime.Server.Models.Main.Relationships.AnimeActor", b =>
                {
                    b.HasOne("Zanime.Server.Models.Main.Actor", "Actor")
                        .WithMany("AnimeActor")
                        .HasForeignKey("ActorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Zanime.Server.Models.Main.Anime", "Anime")
                        .WithMany("AnimeActor")
                        .HasForeignKey("AnimeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Actor");

                    b.Navigation("Anime");
                });

            modelBuilder.Entity("Zanime.Server.Models.Main.Relationships.AnimeCharacter", b =>
                {
                    b.HasOne("Zanime.Server.Models.Main.Anime", "Anime")
                        .WithMany("AnimeCharacter")
                        .HasForeignKey("AnimeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Zanime.Server.Models.Main.Character", "Character")
                        .WithMany("AnimeCharacter")
                        .HasForeignKey("CharacterID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Anime");

                    b.Navigation("Character");
                });

            modelBuilder.Entity("Zanime.Server.Models.Main.Relationships.AnimeComment", b =>
                {
                    b.HasOne("Zanime.Server.Models.Main.Anime", "Anime")
                        .WithMany("AnimeComment")
                        .HasForeignKey("AnimeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Zanime.Server.Models.Main.Comment", "Comment")
                        .WithMany("AnimeComment")
                        .HasForeignKey("CommentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Anime");

                    b.Navigation("Comment");
                });

            modelBuilder.Entity("Zanime.Server.Models.Main.Relationships.AnimeGenre", b =>
                {
                    b.HasOne("Zanime.Server.Models.Main.Anime", "Anime")
                        .WithMany("AnimeGenre")
                        .HasForeignKey("AnimeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Zanime.Server.Models.Main.Genre", "Genre")
                        .WithMany("AnimeGenre")
                        .HasForeignKey("GenreID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Anime");

                    b.Navigation("Genre");
                });

            modelBuilder.Entity("Zanime.Server.Models.Core.User", b =>
                {
                    b.Navigation("Comments");
                });

            modelBuilder.Entity("Zanime.Server.Models.Main.Actor", b =>
                {
                    b.Navigation("ActorCharacters");

                    b.Navigation("AnimeActor");
                });

            modelBuilder.Entity("Zanime.Server.Models.Main.Anime", b =>
                {
                    b.Navigation("AnimeActor");

                    b.Navigation("AnimeCharacter");

                    b.Navigation("AnimeComment");

                    b.Navigation("AnimeGenre");
                });

            modelBuilder.Entity("Zanime.Server.Models.Main.Character", b =>
                {
                    b.Navigation("ActorCharacters");

                    b.Navigation("AnimeCharacter");
                });

            modelBuilder.Entity("Zanime.Server.Models.Main.Comment", b =>
                {
                    b.Navigation("AnimeComment");
                });

            modelBuilder.Entity("Zanime.Server.Models.Main.Genre", b =>
                {
                    b.Navigation("AnimeGenre");
                });
#pragma warning restore 612, 618
        }
    }
}
