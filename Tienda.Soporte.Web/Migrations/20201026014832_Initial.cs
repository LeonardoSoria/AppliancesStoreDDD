using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tienda.Soporte.Web.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    ClientId = table.Column<Guid>(nullable: false),
                    clientName = table.Column<string>(nullable: true),
                    clientLastname = table.Column<string>(nullable: true),
                    clientPhone = table.Column<string>(nullable: true),
                    clientEmail = table.Column<string>(nullable: true),
                    clientAddress = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("clientId", x => x.ClientId);
                });

            migrationBuilder.CreateTable(
                name: "Technicians",
                columns: table => new
                {
                    TechnicianId = table.Column<Guid>(nullable: false),
                    technicianName = table.Column<string>(nullable: true),
                    technicianLastname = table.Column<string>(nullable: true),
                    technicianCI = table.Column<string>(nullable: false),
                    technicianPhone = table.Column<string>(nullable: true),
                    technicianEmail = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("technicianId", x => x.TechnicianId);
                });

            migrationBuilder.CreateTable(
                name: "ServiceOrders",
                columns: table => new
                {
                    ServiceOrderId = table.Column<Guid>(nullable: false),
                    serviceOrderCreationDate = table.Column<DateTime>(nullable: false),
                    ClientId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("serviceOrderId", x => x.ServiceOrderId);
                    table.ForeignKey(
                        name: "FK_ServiceOrders_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "ClientId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    AppointmentId = table.Column<Guid>(nullable: false),
                    appointmentStatus = table.Column<int>(nullable: false),
                    appointmentVisitDate = table.Column<DateTime>(nullable: false),
                    ServiceOrderId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("appointmentId", x => x.AppointmentId);
                    table.ForeignKey(
                        name: "FK_Appointments_ServiceOrders_ServiceOrderId",
                        column: x => x.ServiceOrderId,
                        principalTable: "ServiceOrders",
                        principalColumn: "ServiceOrderId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ServiceOrdersDetails",
                columns: table => new
                {
                    ServiceOrderDetailId = table.Column<Guid>(nullable: false),
                    serviceOrderDetailType = table.Column<int>(nullable: false),
                    serviceOrderDetailPrice = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    ServiceOrderId = table.Column<Guid>(nullable: true),
                    serviceOrderDetailDescription = table.Column<string>(nullable: false),
                    serviceOrderDetailAlternativeAddress = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("serviceOrderDetailId", x => x.ServiceOrderDetailId);
                    table.ForeignKey(
                        name: "FK_ServiceOrdersDetails_ServiceOrders_ServiceOrderId",
                        column: x => x.ServiceOrderId,
                        principalTable: "ServiceOrders",
                        principalColumn: "ServiceOrderId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AppointmentHasTechnicians",
                columns: table => new
                {
                    AppoinmtentHasTechnicianId = table.Column<Guid>(nullable: false),
                    AppointmentId = table.Column<Guid>(nullable: true),
                    TechnicianId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("appointmentHasTechnicianId", x => x.AppoinmtentHasTechnicianId);
                    table.ForeignKey(
                        name: "FK_AppointmentHasTechnicians_Appointments_AppointmentId",
                        column: x => x.AppointmentId,
                        principalTable: "Appointments",
                        principalColumn: "AppointmentId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AppointmentHasTechnicians_Technicians_TechnicianId",
                        column: x => x.TechnicianId,
                        principalTable: "Technicians",
                        principalColumn: "TechnicianId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "JobForms",
                columns: table => new
                {
                    JobFormId = table.Column<Guid>(nullable: false),
                    jobFormDetail = table.Column<string>(nullable: false),
                    jobFormDate = table.Column<DateTime>(nullable: false),
                    AppointmentId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("jobFormId", x => x.JobFormId);
                    table.ForeignKey(
                        name: "FK_JobForms_Appointments_AppointmentId",
                        column: x => x.AppointmentId,
                        principalTable: "Appointments",
                        principalColumn: "AppointmentId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentHasTechnicians_AppointmentId",
                table: "AppointmentHasTechnicians",
                column: "AppointmentId");

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentHasTechnicians_TechnicianId",
                table: "AppointmentHasTechnicians",
                column: "TechnicianId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_ServiceOrderId",
                table: "Appointments",
                column: "ServiceOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_JobForms_AppointmentId",
                table: "JobForms",
                column: "AppointmentId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceOrders_ClientId",
                table: "ServiceOrders",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceOrdersDetails_ServiceOrderId",
                table: "ServiceOrdersDetails",
                column: "ServiceOrderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppointmentHasTechnicians");

            migrationBuilder.DropTable(
                name: "JobForms");

            migrationBuilder.DropTable(
                name: "ServiceOrdersDetails");

            migrationBuilder.DropTable(
                name: "Technicians");

            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DropTable(
                name: "ServiceOrders");

            migrationBuilder.DropTable(
                name: "Clients");
        }
    }
}
