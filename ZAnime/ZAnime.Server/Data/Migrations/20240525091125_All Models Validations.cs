using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Zanime.Server.Migrations
{
    /// <inheritdoc />
    public partial class AllModelsValidations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "abbf1a0d-b645-44dc-b623-1fa75140e7fd", "9e67ca01-5045-4782-a422-3e54a81f2867" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "0d74c1bf-55c6-4b3d-a1ef-15d3ad01475b", "78b817ce-8ccb-4f20-b300-74220f0199f9" });
        }
    }
}
