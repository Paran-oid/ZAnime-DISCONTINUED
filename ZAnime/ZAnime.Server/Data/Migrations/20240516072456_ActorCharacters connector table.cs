using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Zanime.Server.Migrations
{
    /// <inheritdoc />
    public partial class ActorCharactersconnectortable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActorCharacter");

            migrationBuilder.CreateTable(
                name: "ActorCharacters",
                columns: table => new
                {
                    ActorID = table.Column<int>(type: "int", nullable: false),
                    CharacterID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActorCharacters", x => new { x.ActorID, x.CharacterID });
                    table.ForeignKey(
                        name: "FK_ActorCharacters_Actors_ActorID",
                        column: x => x.ActorID,
                        principalTable: "Actors",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActorCharacters_Characters_CharacterID",
                        column: x => x.CharacterID,
                        principalTable: "Characters",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "919c2ddc-f72c-4fea-b960-ac152cd93d48", "cf849e70-deb8-4697-ae78-1090ef17795c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "c2d3931d-26c8-4a94-ab32-40833806974e", "e486c46c-084e-4808-b444-c2f1edf06eb3" });

            migrationBuilder.CreateIndex(
                name: "IX_ActorCharacters_CharacterID",
                table: "ActorCharacters",
                column: "CharacterID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActorCharacters");

            migrationBuilder.CreateTable(
                name: "ActorCharacter",
                columns: table => new
                {
                    ActorsID = table.Column<int>(type: "int", nullable: false),
                    CharactersID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActorCharacter", x => new { x.ActorsID, x.CharactersID });
                    table.ForeignKey(
                        name: "FK_ActorCharacter_Actors_ActorsID",
                        column: x => x.ActorsID,
                        principalTable: "Actors",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActorCharacter_Characters_CharactersID",
                        column: x => x.CharactersID,
                        principalTable: "Characters",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "4c62ba5e-57a0-4e4b-b755-c12198f17bde", "2ebdfef4-0bec-4c17-aa18-30b64ccbe42e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "869dcfa7-8614-4c5c-a341-df591303c6d4", "ca36bed6-0a46-41c2-88e3-108fc56c00b5" });

            migrationBuilder.CreateIndex(
                name: "IX_ActorCharacter_CharactersID",
                table: "ActorCharacter",
                column: "CharactersID");
        }
    }
}