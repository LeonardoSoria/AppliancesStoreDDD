using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tienda.WebApp.Migrations
{
    public partial class InitialDbStructure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OrdenEntregas",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FechaRegistro = table.Column<DateTime>(nullable: false),
                    FechaConsolidacion = table.Column<DateTime>(nullable: true),
                    FechaAnulacion = table.Column<DateTime>(nullable: true),
                    FechaFinalizacion = table.Column<DateTime>(nullable: true),
                    estado = table.Column<int>(nullable: false),
                    nombreCliente = table.Column<string>(nullable: true),
                    telefono = table.Column<string>(nullable: true),
                    latitud = table.Column<decimal>(type: "decimal(18,12)", nullable: true),
                    longitud = table.Column<decimal>(type: "decimal(18,12)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("ordenEntregaId", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrdenEntregas");
        }
    }
}
