using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Zanime.Server.Migrations
{
    /// <inheritdoc />
    public partial class quickremovalofanimerelationships1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AnimesCharacters",
                columns: table => new
                {
                    AnimeID = table.Column<int>(type: "int", nullable: false),
                    CharacterID = table.Column<int>(type: "int", nullable: false)
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
                    AnimeID = table.Column<int>(type: "int", nullable: false),
                    CommentID = table.Column<int>(type: "int", nullable: false)
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
                values: new object[] { "3b9cd898-402b-478a-8a3c-bc60b1f814b0", "f7a67e2b-347b-4dc7-8cd2-a8f0b03af75a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "42818316-2c0f-4226-8d9c-c17ac78866ad", "6e2dd729-2832-4170-8749-c9f62816b59e" });

            migrationBuilder.CreateIndex(
                name: "IX_AnimesCharacters_AnimeID",
                table: "AnimesCharacters",
                column: "AnimeID");

            migrationBuilder.CreateIndex(
                name: "IX_AnimesComments_AnimeID",
                table: "AnimesComments",
                column: "AnimeID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
