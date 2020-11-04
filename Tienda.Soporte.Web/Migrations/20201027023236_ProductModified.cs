using Microsoft.EntityFrameworkCore.Migrations;

namespace Tienda.Soporte.Web.Migrations
{
    public partial class ProductModified : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceOrders_Product_ProductId",
                table: "ServiceOrders");

            migrationBuilder.RenameTable(
                name: "Product",
                newName: "Products");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceOrders_Products_ProductId",
                table: "ServiceOrders",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceOrders_Products_ProductId",
                table: "ServiceOrders");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "Product");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceOrders_Product_ProductId",
                table: "ServiceOrders",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
