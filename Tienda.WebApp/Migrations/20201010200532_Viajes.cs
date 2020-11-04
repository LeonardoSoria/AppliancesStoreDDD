using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tienda.WebApp.Migrations
{
    public partial class Viajes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ViajesEntrega",
                columns: table => new
                {
                    ViajeId = table.Column<Guid>(nullable: false),
                    OrdenEntregaId = table.Column<Guid>(nullable: true),
                    FechaProgramado = table.Column<DateTime>(nullable: false),
                    FechaInicioViaje = table.Column<DateTime>(nullable: true),
                    FechaFinViaje = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ViajesEntrega", x => x.ViajeId);
                    table.ForeignKey(
                        name: "FK_ViajesEntrega_OrdenEntregas_OrdenEntregaId",
                        column: x => x.OrdenEntregaId,
                        principalTable: "OrdenEntregas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SeguimientoViajeItem",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FechaHora = table.Column<DateTime>(nullable: false),
                    latitud = table.Column<decimal>(type: "decimal(18,12)", nullable: true),
                    longitud = table.Column<decimal>(type: "decimal(18,12)", nullable: true),
                    ViajeId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeguimientoViajeItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SeguimientoViajeItem_ViajesEntrega_ViajeId",
                        column: x => x.ViajeId,
                        principalTable: "ViajesEntrega",
                        principalColumn: "ViajeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SeguimientoViajeItem_ViajeId",
                table: "SeguimientoViajeItem",
                column: "ViajeId");

            migrationBuilder.CreateIndex(
                name: "IX_ViajesEntrega_OrdenEntregaId",
                table: "ViajesEntrega",
                column: "OrdenEntregaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SeguimientoViajeItem");

            migrationBuilder.DropTable(
                name: "ViajesEntrega");
        }
    }
}
