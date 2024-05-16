using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Zanime.Server.Migrations
{
    /// <inheritdoc />
    public partial class IdPropertyForcommentclass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_AspNetUsers_UserId",
                table: "Comments");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Comments",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Actors",
                columns: new[] { "ID", "Age", "AnimeID", "Bio", "Dislikes", "Gender", "Likes", "Name", "PicturePath" },
                values: new object[,]
                {
                    { 1, 65, null, "Tom Hanks is an American actor and filmmaker. He is known for his roles in iconic films such as Forrest Gump, Cast Away, and Saving Private Ryan.", 0, "Male", 0, "Tom Hanks", "/images/tom_hanks.jpg" },
                    { 2, 37, null, "Scarlett Johansson is an American actress and singer. She is known for her roles in films like Lost in Translation, The Avengers, and Marriage Story.", 0, "Female", 0, "Scarlett Johansson", "/images/scarlett_johansson.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Animes",
                columns: new[] { "ID", "BackgroundPath", "Description", "EndDate", "Genre", "MainPicturePath", "PicturesPath", "Rating", "ReleaseDate", "Title" },
                values: new object[,]
                {
                    { 1, "none", "Attack on Titan is a Japanese manga series written and illustrated by Hajime Isayama. It depicts a world where humanity resides within enormous walled cities to protect themselves from the Titans, gigantic humanoid creatures.", null, "Action, Drama, Fantasy", "/images/attack_on_titan.jpg", "none", 0f, new DateOnly(2013, 4, 7), "Attack on Titan" },
                    { 2, "none", "My Hero Academia is a Japanese superhero manga series written and illustrated by Kōhei Horikoshi. It follows the story of Izuku Midoriya, a boy born without superpowers in a world where they are the norm, but who still dreams of becoming a superhero himself.", null, "Action, Comedy, Superhero", "/images/my_hero_academia.jpg", "none", 0f, new DateOnly(2016, 4, 3), "My Hero Academia" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "Fname", "Lname", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePicturePath", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1", 0, "e8caede4-965c-4768-8932-6a1d0bdb3eb6", null, false, "John", "Doe", false, null, null, null, null, null, false, "/images/profile1.jpg", "8fc6fb31-33f6-41b1-bc25-506bdbcdf172", false, "user1@example.com" },
                    { "2", 0, "96d51725-75d7-4517-b3bd-680aad93b99a", null, false, "Jane", "Smith", false, null, null, null, null, null, false, "/images/profile2.jpg", "517c2f61-b19b-4ac7-b509-ed94c67cbe31", false, "user2@example.com" }
                });

            migrationBuilder.InsertData(
                table: "Characters",
                columns: new[] { "ID", "Age", "AnimeID", "Bio", "Dislikes", "Gender", "Likes", "Name", "PicturePath" },
                values: new object[,]
                {
                    { 1, 19, null, "Eren Yeager is the protagonist of Attack on Titan. He joins the military to fight the Titans after his hometown is destroyed and his mother is killed.", 0, "Male", 0, "Eren Yeager", "/images/eren_yeager.jpg" },
                    { 2, 16, null, "Izuku Midoriya is the protagonist of My Hero Academia. He is born without a Quirk (superpower) in a world where most people have them, but still aspires to become a hero like his idol, All Might.", 0, "Male", 0, "Izuku Midoriya", "/images/izuku_midoriya.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "ID", "AnimeID", "Content", "Likes", "UserId" },
                values: new object[,]
                {
                    { 1, null, "Great performance by Tom Hanks in Forrest Gump!", 10, "1" },
                    { 2, null, "Attack on Titan is an intense and gripping anime.", 20, "2" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_AspNetUsers_UserId",
                table: "Comments",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_AspNetUsers_UserId",
                table: "Comments");

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Animes",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Animes",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Characters",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Characters",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Comments",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_AspNetUsers_UserId",
                table: "Comments",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}