using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Zanime.Server.Migrations
{
    /// <inheritdoc />
    public partial class NewCRUDforanimemodel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MainPicturePath",
                table: "Animes");

            migrationBuilder.RenameColumn(
                name: "PicturesPath",
                table: "Animes",
                newName: "PicturePath");

            migrationBuilder.UpdateData(
                table: "Animes",
                keyColumn: "ID",
                keyValue: 1,
                column: "PicturePath",
                value: "/images/attack_on_titan.jpg");

            migrationBuilder.UpdateData(
                table: "Animes",
                keyColumn: "ID",
                keyValue: 2,
                column: "PicturePath",
                value: "/images/my_hero_academia.jpg");

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PicturePath",
                table: "Animes",
                newName: "PicturesPath");

            migrationBuilder.AddColumn<string>(
                name: "MainPicturePath",
                table: "Animes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Animes",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "MainPicturePath", "PicturesPath" },
                values: new object[] { "/images/attack_on_titan.jpg", "none" });

            migrationBuilder.UpdateData(
                table: "Animes",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "MainPicturePath", "PicturesPath" },
                values: new object[] { "/images/my_hero_academia.jpg", "none" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "e8caede4-965c-4768-8932-6a1d0bdb3eb6", "8fc6fb31-33f6-41b1-bc25-506bdbcdf172" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "96d51725-75d7-4517-b3bd-680aad93b99a", "517c2f61-b19b-4ac7-b509-ed94c67cbe31" });
        }
    }
}
