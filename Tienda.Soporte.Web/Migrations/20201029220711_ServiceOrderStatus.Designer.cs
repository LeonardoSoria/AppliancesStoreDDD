﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Tienda.Soporte.Infraestructura.Persistence;

namespace Tienda.Soporte.Web.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20201029220711_ServiceOrderStatus")]
    partial class ServiceOrderStatus
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Tienda.Soporte.Domain.Model.Soporte.Appointment", b =>
                {
                    b.Property<Guid>("AppointmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ServiceOrderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Status")
                        .HasColumnName("appointmentStatus")
                        .HasColumnType("int");

                    b.Property<DateTime>("VisitDate")
                        .HasColumnName("appointmentVisitDate")
                        .HasColumnType("datetime2");

                    b.HasKey("AppointmentId")
                        .HasName("appointmentId");

                    b.HasIndex("ServiceOrderId");

                    b.ToTable("Appointments");
                });

            modelBuilder.Entity("Tienda.Soporte.Domain.Model.Soporte.AppointmentHasTechnician", b =>
                {
                    b.Property<Guid>("AppoinmtentHasTechnicianId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AppointmentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("TechnicianId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("AppoinmtentHasTechnicianId")
                        .HasName("appointmentHasTechnicianId");

                    b.HasIndex("AppointmentId");

                    b.HasIndex("TechnicianId");

                    b.ToTable("AppointmentHasTechnicians");
                });

            modelBuilder.Entity("Tienda.Soporte.Domain.Model.Soporte.Client", b =>
                {
                    b.Property<Guid>("ClientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnName("clientAddress")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ClientId")
                        .HasName("clientId");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("Tienda.Soporte.Domain.Model.Soporte.JobForm", b =>
                {
                    b.Property<Guid>("JobFormId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AppointmentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Date")
                        .HasColumnName("jobFormDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Detail")
                        .IsRequired()
                        .HasColumnName("jobFormDetail")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("JobFormId")
                        .HasName("jobFormId");

                    b.HasIndex("AppointmentId");

                    b.ToTable("JobForms");
                });

            modelBuilder.Entity("Tienda.Soporte.Domain.Model.Soporte.Product", b =>
                {
                    b.Property<Guid>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ProductBrand")
                        .IsRequired()
                        .HasColumnName("productBrand")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnName("productName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("ProductPrice")
                        .HasColumnName("productPrice")
                        .HasColumnType("float");

                    b.HasKey("ProductId")
                        .HasName("productId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Tienda.Soporte.Domain.Model.Soporte.ServiceOrder", b =>
                {
                    b.Property<Guid>("ServiceOrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ClientId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnName("serviceOrderCreationDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Status")
                        .HasColumnName("serviceOrderStatus")
                        .HasColumnType("int");

                    b.HasKey("ServiceOrderId")
                        .HasName("serviceOrderId");

                    b.HasIndex("ClientId");

                    b.HasIndex("ProductId");

                    b.ToTable("ServiceOrders");
                });

            modelBuilder.Entity("Tienda.Soporte.Domain.Model.Soporte.ServiceOrderDetail", b =>
                {
                    b.Property<Guid>("ServiceOrderDetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AlternativeAddress")
                        .IsRequired()
                        .HasColumnName("serviceOrderDetailAlternativeAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnName("serviceOrderDetailDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnName("serviceOrderDetailPrice")
                        .HasColumnType("decimal(5,2)");

                    b.Property<Guid?>("ServiceOrderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("ServiceType")
                        .HasColumnName("serviceOrderDetailType")
                        .HasColumnType("int");

                    b.HasKey("ServiceOrderDetailId")
                        .HasName("serviceOrderDetailId");

                    b.HasIndex("ServiceOrderId");

                    b.ToTable("ServiceOrdersDetails");
                });

            modelBuilder.Entity("Tienda.Soporte.Domain.Model.Soporte.Technician", b =>
                {
                    b.Property<Guid>("TechnicianId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CI")
                        .IsRequired()
                        .HasColumnName("technicianCI")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TechnicianId")
                        .HasName("technicianId");

                    b.ToTable("Technicians");
                });

            modelBuilder.Entity("Tienda.Soporte.Domain.Model.Soporte.Appointment", b =>
                {
                    b.HasOne("Tienda.Soporte.Domain.Model.Soporte.ServiceOrder", "ServiceOrder")
                        .WithMany()
                        .HasForeignKey("ServiceOrderId");
                });

            modelBuilder.Entity("Tienda.Soporte.Domain.Model.Soporte.AppointmentHasTechnician", b =>
                {
                    b.HasOne("Tienda.Soporte.Domain.Model.Soporte.Appointment", "Appointment")
                        .WithMany()
                        .HasForeignKey("AppointmentId");

                    b.HasOne("Tienda.Soporte.Domain.Model.Soporte.Technician", "Technician")
                        .WithMany()
                        .HasForeignKey("TechnicianId");
                });

            modelBuilder.Entity("Tienda.Soporte.Domain.Model.Soporte.Client", b =>
                {
                    b.OwnsOne("Tienda.SharedKernel.ValueObjects.Email.EmailValue", "Email", b1 =>
                        {
                            b1.Property<Guid>("ClientId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnName("clientEmail")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("ClientId");

                            b1.ToTable("Clients");

                            b1.WithOwner()
                                .HasForeignKey("ClientId");
                        });

                    b.OwnsOne("Tienda.SharedKernel.ValueObjects.PersonNameValue", "Lastname", b1 =>
                        {
                            b1.Property<Guid>("ClientId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnName("clientLastname")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("ClientId");

                            b1.ToTable("Clients");

                            b1.WithOwner()
                                .HasForeignKey("ClientId");
                        });

                    b.OwnsOne("Tienda.SharedKernel.ValueObjects.PersonNameValue", "Name", b1 =>
                        {
                            b1.Property<Guid>("ClientId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnName("clientName")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("ClientId");

                            b1.ToTable("Clients");

                            b1.WithOwner()
                                .HasForeignKey("ClientId");
                        });

                    b.OwnsOne("Tienda.SharedKernel.ValueObjects.PhoneNumber.PhoneNumberValue", "Phone", b1 =>
                        {
                            b1.Property<Guid>("ClientId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnName("clientPhone")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("ClientId");

                            b1.ToTable("Clients");

                            b1.WithOwner()
                                .HasForeignKey("ClientId");
                        });
                });

            modelBuilder.Entity("Tienda.Soporte.Domain.Model.Soporte.JobForm", b =>
                {
                    b.HasOne("Tienda.Soporte.Domain.Model.Soporte.Appointment", "Appointment")
                        .WithMany()
                        .HasForeignKey("AppointmentId");
                });

            modelBuilder.Entity("Tienda.Soporte.Domain.Model.Soporte.ServiceOrder", b =>
                {
                    b.HasOne("Tienda.Soporte.Domain.Model.Soporte.Client", "Client")
                        .WithMany()
                        .HasForeignKey("ClientId");

                    b.HasOne("Tienda.Soporte.Domain.Model.Soporte.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId");
                });

            modelBuilder.Entity("Tienda.Soporte.Domain.Model.Soporte.ServiceOrderDetail", b =>
                {
                    b.HasOne("Tienda.Soporte.Domain.Model.Soporte.ServiceOrder", "ServiceOrder")
                        .WithMany()
                        .HasForeignKey("ServiceOrderId");
                });

            modelBuilder.Entity("Tienda.Soporte.Domain.Model.Soporte.Technician", b =>
                {
                    b.OwnsOne("Tienda.SharedKernel.ValueObjects.Email.EmailValue", "Email", b1 =>
                        {
                            b1.Property<Guid>("TechnicianId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnName("technicianEmail")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("TechnicianId");

                            b1.ToTable("Technicians");

                            b1.WithOwner()
                                .HasForeignKey("TechnicianId");
                        });

                    b.OwnsOne("Tienda.SharedKernel.ValueObjects.PersonNameValue", "Lastname", b1 =>
                        {
                            b1.Property<Guid>("TechnicianId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnName("technicianLastname")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("TechnicianId");

                            b1.ToTable("Technicians");

                            b1.WithOwner()
                                .HasForeignKey("TechnicianId");
                        });

                    b.OwnsOne("Tienda.SharedKernel.ValueObjects.PersonNameValue", "Name", b1 =>
                        {
                            b1.Property<Guid>("TechnicianId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnName("technicianName")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("TechnicianId");

                            b1.ToTable("Technicians");

                            b1.WithOwner()
                                .HasForeignKey("TechnicianId");
                        });

                    b.OwnsOne("Tienda.SharedKernel.ValueObjects.PhoneNumber.PhoneNumberValue", "Phone", b1 =>
                        {
                            b1.Property<Guid>("TechnicianId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnName("technicianPhone")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("TechnicianId");

                            b1.ToTable("Technicians");

                            b1.WithOwner()
                                .HasForeignKey("TechnicianId");
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
