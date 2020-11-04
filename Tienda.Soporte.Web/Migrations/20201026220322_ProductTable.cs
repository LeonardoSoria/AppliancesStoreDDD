using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tienda.Soporte.Web.Migrations
{
    public partial class ProductTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ProductId",
                table: "ServiceOrders",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    ProductId = table.Column<Guid>(nullable: false),
                    productBrand = table.Column<string>(nullable: false),
                    productName = table.Column<string>(nullable: false),
                    productPrice = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("productId", x => x.ProductId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ServiceOrders_ProductId",
                table: "ServiceOrders",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceOrders_Product_ProductId",
                table: "ServiceOrders",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceOrders_Product_ProductId",
                table: "ServiceOrders");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropIndex(
                name: "IX_ServiceOrders_ProductId",
                table: "ServiceOrders");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "ServiceOrders");
        }
    }
}
