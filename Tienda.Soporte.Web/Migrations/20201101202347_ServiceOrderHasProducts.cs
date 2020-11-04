using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tienda.Soporte.Web.Migrations
{
    public partial class ServiceOrderHasProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceOrders_Products_ProductId",
                table: "ServiceOrders");

            migrationBuilder.DropIndex(
                name: "IX_ServiceOrders_ProductId",
                table: "ServiceOrders");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "ServiceOrders");

            migrationBuilder.CreateTable(
                name: "ServiceOrderHasProducts",
                columns: table => new
                {
                    ServiceOrdersHasProductsId = table.Column<Guid>(nullable: false),
                    ServiceOrderId = table.Column<Guid>(nullable: true),
                    ProductId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("serviceOrderHasProductsId", x => x.ServiceOrdersHasProductsId);
                    table.ForeignKey(
                        name: "FK_ServiceOrderHasProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ServiceOrderHasProducts_ServiceOrders_ServiceOrderId",
                        column: x => x.ServiceOrderId,
                        principalTable: "ServiceOrders",
                        principalColumn: "ServiceOrderId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ServiceOrderHasProducts_ProductId",
                table: "ServiceOrderHasProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceOrderHasProducts_ServiceOrderId",
                table: "ServiceOrderHasProducts",
                column: "ServiceOrderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ServiceOrderHasProducts");

            migrationBuilder.AddColumn<Guid>(
                name: "ProductId",
                table: "ServiceOrders",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ServiceOrders_ProductId",
                table: "ServiceOrders",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceOrders_Products_ProductId",
                table: "ServiceOrders",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
