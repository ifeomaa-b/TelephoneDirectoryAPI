using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TelephoneDirectoryData.Migrations
{
    public partial class Nuls : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "31ee39fd-4d04-417c-af2e-0d5cae0d9275");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "46d0b80f-f7d1-4c90-a46f-fd43fb936d8c");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b1da5e2c-52f2-42ed-9e94-59d4d20a86a5", "1", "Admin", "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e9f81293-d121-495c-a9fd-0c40e5141d27", "2,", "Regular", "Regular" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b1da5e2c-52f2-42ed-9e94-59d4d20a86a5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e9f81293-d121-495c-a9fd-0c40e5141d27");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "31ee39fd-4d04-417c-af2e-0d5cae0d9275", "1", "Admin", "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "46d0b80f-f7d1-4c90-a46f-fd43fb936d8c", "2,", "Regular", "Regular" });
        }
    }
}
