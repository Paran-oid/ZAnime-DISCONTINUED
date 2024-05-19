using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Zanime.Server.Migrations
{
    /// <inheritdoc />
    public partial class quickremovalofanimerelationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnimesCharacters");

            migrationBuilder.DropTable(
                name: "AnimesComments");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "a85e5a59-cd54-44c2-bc35-817c36e24714", "b9b74780-671a-425a-8a9d-798e03b09d84" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "8c3fe90e-4435-4b4f-9a47-b52723b447b5", "855f9a15-35b8-44ae-8a26-24ff0e18c67d" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AnimesCharacters",
                columns: table => new
                {
                    CharacterID = table.Column<int>(type: "int", nullable: false),
                    AnimeID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimesCharacters", x => new { x.CharacterID, x.AnimeID });
                    table.ForeignKey(
                        name: "FK_AnimesCharacters_Animes_AnimeID",
                        column: x => x.AnimeID,
                        principalTable: "Animes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnimesCharacters_Characters_CharacterID",
                        column: x => x.CharacterID,
                        principalTable: "Characters",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AnimesComments",
                columns: table => new
                {
                    CommentID = table.Column<int>(type: "int", nullable: false),
                    AnimeID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimesComments", x => new { x.CommentID, x.AnimeID });
                    table.ForeignKey(
                        name: "FK_AnimesComments_Animes_AnimeID",
                        column: x => x.AnimeID,
                        principalTable: "Animes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnimesComments_Comments_CommentID",
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
                values: new object[] { "fb2ef85e-b8e0-4786-8e6f-b3cc821f0782", "c2e11728-795d-4f3e-9d61-a59d2c08669f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "6533d40d-b02c-48cc-884b-7aa9cd3d8781", "73bf2e60-bb49-4f3e-b868-42c334727646" });

            migrationBuilder.CreateIndex(
                name: "IX_AnimesCharacters_AnimeID",
                table: "AnimesCharacters",
                column: "AnimeID");

            migrationBuilder.CreateIndex(
                name: "IX_AnimesComments_AnimeID",
                table: "AnimesComments",
                column: "AnimeID");
        }
    }
}
