using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Zanime.Server.Migrations
{
    /// <inheritdoc />
    public partial class RelationshipsTablesforAnime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AnimeActor_Actors_ActorID",
                table: "AnimeActor");

            migrationBuilder.DropForeignKey(
                name: "FK_AnimeActor_Animes_AnimeID",
                table: "AnimeActor");

            migrationBuilder.DropForeignKey(
                name: "FK_AnimeCharacter_Animes_AnimeID",
                table: "AnimeCharacter");

            migrationBuilder.DropForeignKey(
                name: "FK_AnimeCharacter_Characters_CharacterID",
                table: "AnimeCharacter");

            migrationBuilder.DropForeignKey(
                name: "FK_AnimeComment_Animes_AnimeID",
                table: "AnimeComment");

            migrationBuilder.DropForeignKey(
                name: "FK_AnimeComment_Comments_CommentID",
                table: "AnimeComment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AnimeComment",
                table: "AnimeComment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AnimeCharacter",
                table: "AnimeCharacter");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AnimeActor",
                table: "AnimeActor");

            migrationBuilder.RenameTable(
                name: "AnimeComment",
                newName: "animeComments");

            migrationBuilder.RenameTable(
                name: "AnimeCharacter",
                newName: "animeCharacters");

            migrationBuilder.RenameTable(
                name: "AnimeActor",
                newName: "AnimesActors");

            migrationBuilder.RenameIndex(
                name: "IX_AnimeComment_AnimeID",
                table: "animeComments",
                newName: "IX_animeComments_AnimeID");

            migrationBuilder.RenameIndex(
                name: "IX_AnimeCharacter_AnimeID",
                table: "animeCharacters",
                newName: "IX_animeCharacters_AnimeID");

            migrationBuilder.RenameIndex(
                name: "IX_AnimeActor_AnimeID",
                table: "AnimesActors",
                newName: "IX_AnimesActors_AnimeID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_animeComments",
                table: "animeComments",
                columns: new[] { "CommentID", "AnimeID" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_animeCharacters",
                table: "animeCharacters",
                columns: new[] { "CharacterID", "AnimeID" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AnimesActors",
                table: "AnimesActors",
                columns: new[] { "ActorID", "AnimeID" });

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

            migrationBuilder.AddForeignKey(
                name: "FK_AnimesActors_Actors_ActorID",
                table: "AnimesActors",
                column: "ActorID",
                principalTable: "Actors",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AnimesActors_Animes_AnimeID",
                table: "AnimesActors",
                column: "AnimeID",
                principalTable: "Animes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropForeignKey(
                name: "FK_AnimesActors_Actors_ActorID",
                table: "AnimesActors");

            migrationBuilder.DropForeignKey(
                name: "FK_AnimesActors_Animes_AnimeID",
                table: "AnimesActors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AnimesActors",
                table: "AnimesActors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_animeComments",
                table: "animeComments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_animeCharacters",
                table: "animeCharacters");

            migrationBuilder.RenameTable(
                name: "AnimesActors",
                newName: "AnimeActor");

            migrationBuilder.RenameTable(
                name: "animeComments",
                newName: "AnimeComment");

            migrationBuilder.RenameTable(
                name: "animeCharacters",
                newName: "AnimeCharacter");

            migrationBuilder.RenameIndex(
                name: "IX_AnimesActors_AnimeID",
                table: "AnimeActor",
                newName: "IX_AnimeActor_AnimeID");

            migrationBuilder.RenameIndex(
                name: "IX_animeComments_AnimeID",
                table: "AnimeComment",
                newName: "IX_AnimeComment_AnimeID");

            migrationBuilder.RenameIndex(
                name: "IX_animeCharacters_AnimeID",
                table: "AnimeCharacter",
                newName: "IX_AnimeCharacter_AnimeID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AnimeActor",
                table: "AnimeActor",
                columns: new[] { "ActorID", "AnimeID" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AnimeComment",
                table: "AnimeComment",
                columns: new[] { "CommentID", "AnimeID" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AnimeCharacter",
                table: "AnimeCharacter",
                columns: new[] { "CharacterID", "AnimeID" });

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

            migrationBuilder.AddForeignKey(
                name: "FK_AnimeActor_Actors_ActorID",
                table: "AnimeActor",
                column: "ActorID",
                principalTable: "Actors",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AnimeActor_Animes_AnimeID",
                table: "AnimeActor",
                column: "AnimeID",
                principalTable: "Animes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AnimeCharacter_Animes_AnimeID",
                table: "AnimeCharacter",
                column: "AnimeID",
                principalTable: "Animes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AnimeCharacter_Characters_CharacterID",
                table: "AnimeCharacter",
                column: "CharacterID",
                principalTable: "Characters",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AnimeComment_Animes_AnimeID",
                table: "AnimeComment",
                column: "AnimeID",
                principalTable: "Animes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AnimeComment_Comments_CommentID",
                table: "AnimeComment",
                column: "CommentID",
                principalTable: "Comments",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}