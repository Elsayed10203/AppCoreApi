using Microsoft.EntityFrameworkCore.Migrations;

namespace AppCoreProj.Migrations
{
    public partial class IdentiyMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8acabb4f-6f81-4464-bc99-6daeed2a6ac6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d2195616-3f8c-4d03-81ed-de6147b32c2a");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b035df02-b846-4d0f-b7cd-a44fde259567", "aa1d80d4-b181-4dad-944b-593051accdb7", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "89b61a3a-0fee-4271-965b-ff29077bf568", "405f1244-bde7-43f2-ad8a-333ce0ba3389", "User", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "89b61a3a-0fee-4271-965b-ff29077bf568");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b035df02-b846-4d0f-b7cd-a44fde259567");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d2195616-3f8c-4d03-81ed-de6147b32c2a", "d0208e14-3f82-464c-acc8-26c3231e129b", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8acabb4f-6f81-4464-bc99-6daeed2a6ac6", "cd512347-bead-49c8-997b-503d35fb4d6e", "User", "USER" });
        }
    }
}
