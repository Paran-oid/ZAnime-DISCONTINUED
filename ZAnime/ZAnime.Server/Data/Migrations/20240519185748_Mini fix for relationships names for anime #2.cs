using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Zanime.Server.Migrations
{
    /// <inheritdoc />
    public partial class Minifixforrelationshipsnamesforanime2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
