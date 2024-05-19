using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Zanime.Server.Migrations
{
    /// <inheritdoc />
    public partial class Minifixforrelationshipsnamesforanime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_animeCharacters_Animes_AnimeID",
                table: "animeCharacters");

            migrationBuilder.DropForeignKey(
                name: "FK_animeCharacters_Characters_CharacterID",
                table: "animeCharacters");

            migrationBuilder.DropForeignKey(
                name: "FK_animeComments_Animes_AnimeID",
                table: "animeComments");

            migrationBuilder.DropForeignKey(
                name: "FK_animeComments_Comments_CommentID",
                table: "animeComments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_animeComments",
                table: "animeComments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_animeCharacters",
                table: "animeCharacters");

            migrationBuilder.RenameTable(
                name: "animeComments",
                newName: "AnimeComments");

            migrationBuilder.RenameTable(
                name: "animeCharacters",
                newName: "AnimeCharacters");

            migrationBuilder.RenameIndex(
                name: "IX_animeComments_AnimeID",
                table: "AnimeComments",
                newName: "IX_AnimeComments_AnimeID");

            migrationBuilder.RenameIndex(
                name: "IX_animeCharacters_AnimeID",
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
                newName: "animeComments");

            migrationBuilder.RenameTable(
                name: "AnimeCharacters",
                newName: "animeCharacters");

            migrationBuilder.RenameIndex(
                name: "IX_AnimeComments_AnimeID",
                table: "animeComments",
                newName: "IX_animeComments_AnimeID");

            migrationBuilder.RenameIndex(
                name: "IX_AnimeCharacters_AnimeID",
                table: "animeCharacters",
                newName: "IX_animeCharacters_AnimeID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_animeComments",
                table: "animeComments",
                columns: new[] { "CommentID", "AnimeID" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_animeCharacters",
                table: "animeCharacters",
                columns: new[] { "CharacterID", "AnimeID" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "79cd0298-91de-489c-b263-05828f9eabaa", "617629f7-49f2-4c72-8b92-481d50b4f0db" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "3bb77a1a-0b92-41a4-a812-5915e985cdec", "b0fca825-d7e6-4373-83fe-4add045c86aa" });

            migrationBuilder.AddForeignKey(
                name: "FK_animeCharacters_Animes_AnimeID",
                table: "animeCharacters",
                column: "AnimeID",
                principalTable: "Animes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_animeCharacters_Characters_CharacterID",
                table: "animeCharacters",
                column: "CharacterID",
                principalTable: "Characters",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_animeComments_Animes_AnimeID",
                table: "animeComments",
                column: "AnimeID",
                principalTable: "Animes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_animeComments_Comments_CommentID",
                table: "animeComments",
                column: "CommentID",
                principalTable: "Comments",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}