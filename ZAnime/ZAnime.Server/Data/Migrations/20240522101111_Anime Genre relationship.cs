using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Zanime.Server.Migrations
{
    /// <inheritdoc />
    public partial class AnimeGenrerelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Genre",
                table: "Animes");

            migrationBuilder.CreateTable(
                name: "AnimeGenres",
                columns: table => new
                {
                    AnimeID = table.Column<int>(type: "int", nullable: false),
                    GenreID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimeGenres", x => new { x.GenreID, x.AnimeID });
                    table.ForeignKey(
                        name: "FK_AnimeGenres_Animes_AnimeID",
                        column: x => x.AnimeID,
                        principalTable: "Animes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnimeGenres_Genres_GenreID",
                        column: x => x.GenreID,
                        principalTable: "Genres",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "b6bd8759-58c0-47fb-abd5-a0f5a5784f6d", "7e7fafdc-c3f0-4219-8ffd-489e69929378" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "d6b2f1e3-e1f0-433f-96c3-7d93ce11b32e", "c1bb81f1-f667-4415-aa53-5486366550a2" });

            migrationBuilder.CreateIndex(
                name: "IX_AnimeGenres_AnimeID",
                table: "AnimeGenres",
                column: "AnimeID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnimeGenres");

            migrationBuilder.AddColumn<string>(
                name: "Genre",
                table: "Animes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Animes",
                keyColumn: "ID",
                keyValue: 1,
                column: "Genre",
                value: "Action, Drama, Fantasy");

            migrationBuilder.UpdateData(
                table: "Animes",
                keyColumn: "ID",
                keyValue: 2,
                column: "Genre",
                value: "Action, Comedy, Superhero");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "448d3247-a504-4d6b-b3f6-67cd61a333c1", "24c4ed25-8ac5-45a4-be6a-5eebbc01e954" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "68f01b87-37d5-4adc-a47c-caf259172963", "f5bd4426-70a7-4abf-a03b-cb06c4c26ba4" });
        }
    }
}
