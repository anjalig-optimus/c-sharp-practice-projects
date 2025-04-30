using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Person_json.Migrations.AuthDb
{
    /// <inheritdoc />
    public partial class fifth : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "77cd32d9-c599-412e-ba2e-425b49194338", "77cd32d9-c599-412e-ba2e-425b49194338", "Reader", "READER" },
                    { "a2729e9e-cb67-461c-969e-4212991440c0", "a2729e9e-cb67-461c-969e-4212991440c0", "Writer", "WRITER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "77cd32d9-c599-412e-ba2e-425b49194338");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a2729e9e-cb67-461c-969e-4212991440c0");
        }
    }
}
