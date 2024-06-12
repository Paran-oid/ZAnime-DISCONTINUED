using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Zanime.Server.Migrations
{
    /// <inheritdoc />
    public partial class Minifixforrelationshipsnamesforanime1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AnimeCharacters_Animes_AnimeID",
                table: "AnimeCharacters");

            migrationBuilder.DropForeignKey(
                name: "FK_AnimeCharacters_Characters_CharacterID",
                table: "AnimeCharacters");

            migrationBuilder.DropForeignKey(
                name: "FK_AnimeComments_Animes_AnimeID",
                table: "AnimeComments");

            migrationBuilder.DropForeignKey(
                name: "FK_AnimeComments_Comments_CommentID",
                table: "AnimeComments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AnimeComments",
                table: "AnimeComments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AnimeCharacters",
                table: "AnimeCharacters");

            migrationBuilder.RenameTable(
                name: "AnimeComments",
                newName: "AnimesComments");

            migrationBuilder.RenameTable(
                name: "AnimeCharacters",
                newName: "AnimeCharacters");

            migrationBuilder.RenameIndex(
                name: "IX_AnimeComments_AnimeID",
                table: "AnimesComments",
                newName: "IX_AnimesComments_AnimeID");

            migrationBuilder.RenameIndex(
                name: "IX_AnimeCharacters_AnimeID",
                table: "AnimeCharacters",
                newName: "IX_AnimeCharacters_AnimeID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AnimesComments",
                table: "AnimesComments",
                columns: new[] { "CommentID", "AnimeID" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AnimeCharacters",
                table: "AnimeCharacters",
                columns: new[] { "CharacterID", "AnimeID" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "08a9343b-74d0-464b-b277-71d1f5a7de16", "deb86e8a-ef96-4930-a243-d098f239b0db" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "01fb36ec-622a-4237-b86b-ce32fc9cd97d", "43fc4228-0276-42b9-a4ee-afafafb0642a" });

            migrationBuilder.AddForeignKey(
                name: "FK_AnimeCharacters_Animes_AnimeID",
                table: "AnimeCharacters",
                column: "AnimeID",
                principalTable: "Animes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AnimeCharacters_Characters_CharacterID",
                table: "AnimeCharacters",
                column: "CharacterID",
                principalTable: "Characters",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AnimesComments_Animes_AnimeID",
                table: "AnimesComments",
                column: "AnimeID",
                principalTable: "Animes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AnimesComments_Comments_CommentID",
                table: "AnimesComments",
                column: "CommentID",
                principalTable: "Comments",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AnimeCharacters_Animes_AnimeID",
                table: "AnimeCharacters");

            migrationBuilder.DropForeignKey(
                name: "FK_AnimeCharacters_Characters_CharacterID",
                table: "AnimeCharacters");

            migrationBuilder.DropForeignKey(
                name: "FK_AnimesComments_Animes_AnimeID",
                table: "AnimesComments");

            migrationBuilder.DropForeignKey(
                name: "FK_AnimesComments_Comments_CommentID",
                table: "AnimesComments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AnimesComments",
                table: "AnimesComments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AnimeCharacters",
                table: "AnimeCharacters");

            migrationBuilder.RenameTable(
                name: "AnimesComments",
                newName: "AnimeComments");

            migrationBuilder.RenameTable(
                name: "AnimeCharacters",
                newName: "AnimeCharacters");

            migrationBuilder.RenameIndex(
                name: "IX_AnimesComments_AnimeID",
                table: "AnimeComments",
                newName: "IX_AnimeComments_AnimeID");

            migrationBuilder.RenameIndex(
                name: "IX_AnimeCharacters_AnimeID",
                table: "AnimeCharacters",
                newName: "IX_AnimeCharacters_AnimeID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AnimeComments",
                table: "AnimeComments",
                columns: new[] { "CommentID", "AnimeID" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AnimeCharacters",
                table: "AnimeCharacters",
                columns: new[] { "CharacterID", "AnimeID" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "974bd181-6c8a-4230-82e8-855d77c9a883", "0557fd16-1402-438c-93b0-9efea493c0cd" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "fe3f9ff4-1495-47d4-870c-1130af660ef2", "0b7aa0f8-7c55-4b02-abd3-9aff1580889e" });

            migrationBuilder.AddForeignKey(
                name: "FK_AnimeCharacters_Animes_AnimeID",
                table: "AnimeCharacters",
                column: "AnimeID",
                principalTable: "Animes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AnimeCharacters_Characters_CharacterID",
                table: "AnimeCharacters",
                column: "CharacterID",
                principalTable: "Characters",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AnimeComments_Animes_AnimeID",
                table: "AnimeComments",
                column: "AnimeID",
                principalTable: "Animes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AnimeComments_Comments_CommentID",
                table: "AnimeComments",
                column: "CommentID",
                principalTable: "Comments",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}