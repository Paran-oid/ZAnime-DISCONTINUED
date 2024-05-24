using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Zanime.Server.Migrations
{
    /// <inheritdoc />
    public partial class Tweaksforcomments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnimesComments");

            migrationBuilder.AddColumn<int>(
                name: "AnimeID",
                table: "Comments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "668e3648-2057-4e03-b5f2-7800885291e5", "3dd88ba7-17ae-478f-ba43-66bff0ba1512" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "e26500d3-18fe-4b73-ba7c-c16f23227612", "2c8d6dad-ff8e-4d0c-a46a-9d3f03156a5e" });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "ID",
                keyValue: 1,
                column: "AnimeID",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "ID",
                keyValue: 2,
                column: "AnimeID",
                value: 2);

            migrationBuilder.CreateIndex(
                name: "IX_Comments_AnimeID",
                table: "Comments",
                column: "AnimeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Animes_AnimeID",
                table: "Comments",
                column: "AnimeID",
                principalTable: "Animes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Animes_AnimeID",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_AnimeID",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "AnimeID",
                table: "Comments");

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
                values: new object[] { "24a0ff4e-e650-4c67-a63b-e71574f55224", "50d6f261-aab9-4b75-92ad-75f0f66b287c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "1fad9998-80c0-4d30-959c-fdf01539f091", "e058cf39-e5d0-4116-8fc5-d06850ac644a" });

            migrationBuilder.CreateIndex(
                name: "IX_AnimesComments_AnimeID",
                table: "AnimesComments",
                column: "AnimeID");
        }
    }
}
