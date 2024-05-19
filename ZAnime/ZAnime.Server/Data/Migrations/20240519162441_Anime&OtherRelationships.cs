using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Zanime.Server.Migrations
{
    /// <inheritdoc />
    public partial class AnimeOtherRelationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Actors_Animes_AnimeID",
                table: "Actors");

            migrationBuilder.DropForeignKey(
                name: "FK_Characters_Animes_AnimeID",
                table: "Characters");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Animes_AnimeID",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_AnimeID",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Characters_AnimeID",
                table: "Characters");

            migrationBuilder.DropIndex(
                name: "IX_Actors_AnimeID",
                table: "Actors");

            migrationBuilder.DropColumn(
                name: "AnimeID",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "AnimeID",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "AnimeID",
                table: "Actors");

            migrationBuilder.CreateTable(
                name: "AnimeActor",
                columns: table => new
                {
                    AnimeID = table.Column<int>(type: "int", nullable: false),
                    ActorID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimeActor", x => new { x.ActorID, x.AnimeID });
                    table.ForeignKey(
                        name: "FK_AnimeActor_Actors_ActorID",
                        column: x => x.ActorID,
                        principalTable: "Actors",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnimeActor_Animes_AnimeID",
                        column: x => x.AnimeID,
                        principalTable: "Animes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AnimeCharacter",
                columns: table => new
                {
                    AnimeID = table.Column<int>(type: "int", nullable: false),
                    CharacterID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimeCharacter", x => new { x.CharacterID, x.AnimeID });
                    table.ForeignKey(
                        name: "FK_AnimeCharacter_Animes_AnimeID",
                        column: x => x.AnimeID,
                        principalTable: "Animes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnimeCharacter_Characters_CharacterID",
                        column: x => x.CharacterID,
                        principalTable: "Characters",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AnimeComment",
                columns: table => new
                {
                    AnimeID = table.Column<int>(type: "int", nullable: false),
                    CommentID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimeComment", x => new { x.CommentID, x.AnimeID });
                    table.ForeignKey(
                        name: "FK_AnimeComment_Animes_AnimeID",
                        column: x => x.AnimeID,
                        principalTable: "Animes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnimeComment_Comments_CommentID",
                        column: x => x.CommentID,
                        principalTable: "Comments",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "48663b57-b01a-4e2e-8d87-11291e74803d", "dab1c819-3e60-408b-a839-e61bc48936b4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "e5c5de51-b1e3-43d3-834b-5e2645dd77c7", "88684463-c3b7-4c6e-bb03-c6390d087e26" });

            migrationBuilder.CreateIndex(
                name: "IX_AnimeActor_AnimeID",
                table: "AnimeActor",
                column: "AnimeID");

            migrationBuilder.CreateIndex(
                name: "IX_AnimeCharacter_AnimeID",
                table: "AnimeCharacter",
                column: "AnimeID");

            migrationBuilder.CreateIndex(
                name: "IX_AnimeComment_AnimeID",
                table: "AnimeComment",
                column: "AnimeID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnimeActor");

            migrationBuilder.DropTable(
                name: "AnimeCharacter");

            migrationBuilder.DropTable(
                name: "AnimeComment");

            migrationBuilder.AddColumn<int>(
                name: "AnimeID",
                table: "Comments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AnimeID",
                table: "Characters",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AnimeID",
                table: "Actors",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Actors",
                keyColumn: "ID",
                keyValue: 1,
                column: "AnimeID",
                value: null);

            migrationBuilder.UpdateData(
                table: "Actors",
                keyColumn: "ID",
                keyValue: 2,
                column: "AnimeID",
                value: null);

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

            migrationBuilder.UpdateData(
                table: "Characters",
                keyColumn: "ID",
                keyValue: 1,
                column: "AnimeID",
                value: null);

            migrationBuilder.UpdateData(
                table: "Characters",
                keyColumn: "ID",
                keyValue: 2,
                column: "AnimeID",
                value: null);

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "ID",
                keyValue: 1,
                column: "AnimeID",
                value: null);

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "ID",
                keyValue: 2,
                column: "AnimeID",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_Comments_AnimeID",
                table: "Comments",
                column: "AnimeID");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_AnimeID",
                table: "Characters",
                column: "AnimeID");

            migrationBuilder.CreateIndex(
                name: "IX_Actors_AnimeID",
                table: "Actors",
                column: "AnimeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Actors_Animes_AnimeID",
                table: "Actors",
                column: "AnimeID",
                principalTable: "Animes",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_Animes_AnimeID",
                table: "Characters",
                column: "AnimeID",
                principalTable: "Animes",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Animes_AnimeID",
                table: "Comments",
                column: "AnimeID",
                principalTable: "Animes",
                principalColumn: "ID");
        }
    }
}