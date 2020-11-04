using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tienda.WebApp.Migrations
{
    public partial class ItemEntrega : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ItemEntregas",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    OrdenEntregaId = table.Column<Guid>(nullable: true),
                    codigo = table.Column<string>(nullable: false),
                    descripcion = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemEntregas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemEntregas_OrdenEntregas_OrdenEntregaId",
                        column: x => x.OrdenEntregaId,
                        principalTable: "OrdenEntregas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItemEntregas_OrdenEntregaId",
                table: "ItemEntregas",
                column: "OrdenEntregaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemEntregas");
        }
    }
}
