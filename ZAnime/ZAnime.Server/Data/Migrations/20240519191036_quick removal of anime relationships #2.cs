using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Zanime.Server.Migrations
{
    /// <inheritdoc />
    public partial class quickremovalofanimerelationships2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "609546ee-c078-4689-95eb-1dd588a82f38", "83cc9934-6529-4cda-8510-c8be9713d76f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "9dc7c191-8c25-4f9e-94a3-8d69bfcbb819", "c8a39f6c-2fd9-4832-b6b6-249ad53e7a95" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
