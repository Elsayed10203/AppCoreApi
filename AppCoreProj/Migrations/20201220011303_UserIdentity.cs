using Microsoft.EntityFrameworkCore.Migrations;

namespace AppCoreProj.Migrations
{
    public partial class UserIdentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "89b61a3a-0fee-4271-965b-ff29077bf568");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b035df02-b846-4d0f-b7cd-a44fde259567");

            migrationBuilder.RenameColumn(
                name: "lastupdate",
                table: "Product",
                newName: "lastupdateted");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "cf04fec8-140c-448c-8690-3ee955ecc794", "a410dde6-667f-4ed0-9784-aa76a17b05eb", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "04796d9b-665b-4904-85f0-9abff87dc821", "417267eb-46cf-4092-9ed4-138882027d64", "User", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "04796d9b-665b-4904-85f0-9abff87dc821");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cf04fec8-140c-448c-8690-3ee955ecc794");

            migrationBuilder.RenameColumn(
                name: "lastupdateted",
                table: "Product",
                newName: "lastupdate");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b035df02-b846-4d0f-b7cd-a44fde259567", "aa1d80d4-b181-4dad-944b-593051accdb7", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "89b61a3a-0fee-4271-965b-ff29077bf568", "405f1244-bde7-43f2-ad8a-333ce0ba3389", "User", "USER" });
        }
    }
}
