using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Zanime.Server.Migrations
{
    public partial class AnimeSeedling1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "f8789861-3931-4f4f-b458-f6967979192a", "f324632f-dbcb-41ca-93a7-3bb45efea8f8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "3ba29971-e5b5-4058-bfef-387eee9cba83", "d1980034-2b29-4de1-87c4-73cfefc580c1" });

            migrationBuilder.InsertData(
                table: "Animes",
                columns: new[] { "ID", "BackgroundPath", "Description", "EndDate", "Genre", "PicturePath", "Rating", "ReleaseDate", "Title" },
                values: new object[,]
                {
                    { 1, "none", "Attack on Titan is a Japanese manga series written and illustrated by Hajime Isayama. It depicts a world where humanity resides within enormous walled cities to protect themselves from the Titans, gigantic humanoid creatures.", null, "Action, Drama, Fantasy", "/images/attack_on_titan.jpg", 0f, new DateOnly(2013, 4, 7), "Attack on Titan" },
                    { 2, "none", "My Hero Academia is a Japanese superhero manga series written and illustrated by Kōhei Horikoshi. It follows the story of Izuku Midoriya, a boy born without superpowers in a world where they are the norm, but who still dreams of becoming a superhero himself.", null, "Action, Comedy, Superhero", "/images/my_hero_academia.jpg", 0f, new DateOnly(2016, 4, 3), "My Hero Academia" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "609546ee-c078-4689-95eb-1dd588a82f38", "83cc9934-6529-4cda-8510-c8be9713d76f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "9dc7c191-8c25-4f9e-94a3-8d69bfcbb819", "c8a39f6c-2fd9-4832-b6b6-249ad53e7a95" });
        }
    }
}