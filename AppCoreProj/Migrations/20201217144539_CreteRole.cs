using Microsoft.EntityFrameworkCore.Migrations;

namespace AppCoreProj.Migrations
{
    public partial class CreteRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3d95512b-a42f-483c-a0ef-b0c98b0ec8a2", "7b6f15ba-79ff-441f-9589-bfa612f63505", "Admin", "ADMIN" },
                    { "c8ee2be2-195f-4f14-a1f8-7e2c618bcdc8", "8963da0a-32d5-4d61-993c-c8dadb16cac8", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "ProdId", "LastUpdated", "Name", "Photo", "Price" },
                values: new object[,]
                {
                    { 1, "12/3/2013", "ProductTst1", "", 1200m },
                    { 2, "12/3/2013", "ProductTst1", "", 1200m }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d95512b-a42f-483c-a0ef-b0c98b0ec8a2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c8ee2be2-195f-4f14-a1f8-7e2c618bcdc8");

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ProdId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ProdId",
                keyValue: 2);
        }
    }
}
