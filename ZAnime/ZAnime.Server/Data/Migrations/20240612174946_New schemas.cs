using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Zanime.Server.Migrations
{
    /// <inheritdoc />
    public partial class Newschemas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AnimeActors_Actors_ActorID",
                table: "AnimeActors");

            migrationBuilder.DropForeignKey(
                name: "FK_AnimeActors_Animes_AnimeID",
                table: "AnimeActors");

            migrationBuilder.DropForeignKey(
                name: "FK_AnimeCharacters_Animes_AnimeID",
                table: "AnimeCharacters");

            migrationBuilder.DropForeignKey(
                name: "FK_AnimeCharacters_Characters_CharacterID",
                table: "AnimeCharacters");

            migrationBuilder.DropForeignKey(
                name: "FK_AnimeGenres_Animes_AnimeID",
                table: "AnimeGenres");

            migrationBuilder.DropForeignKey(
                name: "FK_AnimeGenres_Genres_GenreID",
                table: "AnimeGenres");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AnimeGenres",
                table: "AnimeGenres");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AnimeCharacters",
                table: "AnimeCharacters");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AnimeActors",
                table: "AnimeActors");

            migrationBuilder.EnsureSchema(
                name: "anr");

            migrationBuilder.EnsureSchema(
                name: "anm");

            migrationBuilder.RenameTable(
                name: "Genres",
                newName: "Genres",
                newSchema: "anm");

            migrationBuilder.RenameTable(
                name: "Comments",
                newName: "Comments",
                newSchema: "anm");

            migrationBuilder.RenameTable(
                name: "Characters",
                newName: "Characters",
                newSchema: "anm");

            migrationBuilder.RenameTable(
                name: "Animes",
                newName: "Animes",
                newSchema: "anm");

            migrationBuilder.RenameTable(
                name: "Actors",
                newName: "Actors",
                newSchema: "anm");

            migrationBuilder.RenameTable(
                name: "ActorCharacters",
                newName: "ActorCharacters",
                newSchema: "anr");

            migrationBuilder.RenameTable(
                name: "AnimeGenres",
                newName: "ActorGenres",
                newSchema: "anr");

            migrationBuilder.RenameTable(
                name: "AnimeCharacters",
                newName: "AnimeCharacters",
                newSchema: "anr");

            migrationBuilder.RenameTable(
                name: "AnimeActors",
                newName: "AnimeActors",
                newSchema: "anr");

            migrationBuilder.RenameIndex(
                name: "IX_AnimeGenres_AnimeID",
                schema: "anr",
                table: "ActorGenres",
                newName: "IX_ActorGenres_AnimeID");

            migrationBuilder.RenameIndex(
                name: "IX_AnimeCharacters_AnimeID",
                schema: "anr",
                table: "AnimeCharacters",
                newName: "IX_AnimeCharacters_AnimeID");

            migrationBuilder.RenameIndex(
                name: "IX_AnimeActors_AnimeID",
                schema: "anr",
                table: "AnimeActors",
                newName: "IX_AnimeActors_AnimeID");

            migrationBuilder.AlterColumn<string>(
                name: "Lname",
                table: "AspNetUsers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Fname",
                table: "AspNetUsers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ActorGenres",
                schema: "anr",
                table: "ActorGenres",
                columns: new[] { "GenreID", "AnimeID" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AnimeCharacters",
                schema: "anr",
                table: "AnimeCharacters",
                columns: new[] { "CharacterID", "AnimeID" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AnimeActors",
                schema: "anr",
                table: "AnimeActors",
                columns: new[] { "ActorID", "AnimeID" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "60052599-33c1-4ebc-80f3-3768b133dd5f", "6c7a3e0d-d861-4a6e-b527-ee115d7b6d9d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "11470131-7aab-476e-b4ba-316703558fd2", "736b04b2-4aea-46fd-a00b-d8ef520726fa" });

            migrationBuilder.AddForeignKey(
                name: "FK_ActorGenres_Animes_AnimeID",
                schema: "anr",
                table: "ActorGenres",
                column: "AnimeID",
                principalSchema: "anm",
                principalTable: "Animes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ActorGenres_Genres_GenreID",
                schema: "anr",
                table: "ActorGenres",
                column: "GenreID",
                principalSchema: "anm",
                principalTable: "Genres",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AnimeActors_Actors_ActorID",
                schema: "anr",
                table: "AnimeActors",
                column: "ActorID",
                principalSchema: "anm",
                principalTable: "Actors",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AnimeActors_Animes_AnimeID",
                schema: "anr",
                table: "AnimeActors",
                column: "AnimeID",
                principalSchema: "anm",
                principalTable: "Animes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AnimeCharacters_Animes_AnimeID",
                schema: "anr",
                table: "AnimeCharacters",
                column: "AnimeID",
                principalSchema: "anm",
                principalTable: "Animes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AnimeCharacters_Characters_CharacterID",
                schema: "anr",
                table: "AnimeCharacters",
                column: "CharacterID",
                principalSchema: "anm",
                principalTable: "Characters",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActorGenres_Animes_AnimeID",
                schema: "anr",
                table: "ActorGenres");

            migrationBuilder.DropForeignKey(
                name: "FK_ActorGenres_Genres_GenreID",
                schema: "anr",
                table: "ActorGenres");

            migrationBuilder.DropForeignKey(
                name: "FK_AnimeActors_Actors_ActorID",
                schema: "anr",
                table: "AnimeActors");

            migrationBuilder.DropForeignKey(
                name: "FK_AnimeActors_Animes_AnimeID",
                schema: "anr",
                table: "AnimeActors");

            migrationBuilder.DropForeignKey(
                name: "FK_AnimeCharacters_Animes_AnimeID",
                schema: "anr",
                table: "AnimeCharacters");

            migrationBuilder.DropForeignKey(
                name: "FK_AnimeCharacters_Characters_CharacterID",
                schema: "anr",
                table: "AnimeCharacters");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AnimeCharacters",
                schema: "anr",
                table: "AnimeCharacters");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AnimeActors",
                schema: "anr",
                table: "AnimeActors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ActorGenres",
                schema: "anr",
                table: "ActorGenres");

            migrationBuilder.RenameTable(
                name: "Genres",
                schema: "anm",
                newName: "Genres");

            migrationBuilder.RenameTable(
                name: "Comments",
                schema: "anm",
                newName: "Comments");

            migrationBuilder.RenameTable(
                name: "Characters",
                schema: "anm",
                newName: "Characters");

            migrationBuilder.RenameTable(
                name: "Animes",
                schema: "anm",
                newName: "Animes");

            migrationBuilder.RenameTable(
                name: "Actors",
                schema: "anm",
                newName: "Actors");

            migrationBuilder.RenameTable(
                name: "ActorCharacters",
                schema: "anr",
                newName: "ActorCharacters");

            migrationBuilder.RenameTable(
                name: "AnimeCharacters",
                schema: "anr",
                newName: "AnimeCharacters");

            migrationBuilder.RenameTable(
                name: "AnimeActors",
                schema: "anr",
                newName: "AnimeActors");

            migrationBuilder.RenameTable(
                name: "ActorGenres",
                schema: "anr",
                newName: "AnimeGenres");

            migrationBuilder.RenameIndex(
                name: "IX_AnimeCharacters_AnimeID",
                table: "AnimeCharacters",
                newName: "IX_AnimeCharacters_AnimeID");

            migrationBuilder.RenameIndex(
                name: "IX_AnimeActors_AnimeID",
                table: "AnimeActors",
                newName: "IX_AnimeActors_AnimeID");

            migrationBuilder.RenameIndex(
                name: "IX_ActorGenres_AnimeID",
                table: "AnimeGenres",
                newName: "IX_AnimeGenres_AnimeID");

            migrationBuilder.AlterColumn<string>(
                name: "Lname",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Fname",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_AnimeCharacters",
                table: "AnimeCharacters",
                columns: new[] { "CharacterID", "AnimeID" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AnimeActors",
                table: "AnimeActors",
                columns: new[] { "ActorID", "AnimeID" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AnimeGenres",
                table: "AnimeGenres",
                columns: new[] { "GenreID", "AnimeID" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "3376fb2d-f3aa-42db-91b9-b59a4cae1c17", "8b60648e-2b5e-4130-955b-6a855d2d3368" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "fd94fdd7-ed07-4689-9cb6-2db6c7643c9b", "0045cf3c-3ad4-4b19-8e77-0d9a6035a8c7" });

            migrationBuilder.AddForeignKey(
                name: "FK_AnimeActors_Actors_ActorID",
                table: "AnimeActors",
                column: "ActorID",
                principalTable: "Actors",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AnimeActors_Animes_AnimeID",
                table: "AnimeActors",
                column: "AnimeID",
                principalTable: "Animes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

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
                name: "FK_AnimeGenres_Animes_AnimeID",
                table: "AnimeGenres",
                column: "AnimeID",
                principalTable: "Animes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AnimeGenres_Genres_GenreID",
                table: "AnimeGenres",
                column: "GenreID",
                principalTable: "Genres",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}