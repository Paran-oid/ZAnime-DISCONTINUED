using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Zanime.Server.Migrations
{
    /// <inheritdoc />
    public partial class AllModelsValidationsFIX1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Rating",
                table: "Animes",
                type: "float",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.UpdateData(
                table: "Animes",
                keyColumn: "ID",
                keyValue: 1,
                column: "Rating",
                value: 0.0);

            migrationBuilder.UpdateData(
                table: "Animes",
                keyColumn: "ID",
                keyValue: 2,
                column: "Rating",
                value: 0.0);

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "Rating",
                table: "Animes",
                type: "real",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.UpdateData(
                table: "Animes",
                keyColumn: "ID",
                keyValue: 1,
                column: "Rating",
                value: 0f);

            migrationBuilder.UpdateData(
                table: "Animes",
                keyColumn: "ID",
                keyValue: 2,
                column: "Rating",
                value: 0f);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "9860362c-5a57-4090-9fc2-cb1cedf2ae13", "4705b196-bce8-4c8f-bae9-74576e6ca476" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "35cfeebd-ebc3-4574-8571-4c00b83f4061", "2b3a83bd-9a73-4cc8-b778-3986f2948528" });
        }
    }
}
