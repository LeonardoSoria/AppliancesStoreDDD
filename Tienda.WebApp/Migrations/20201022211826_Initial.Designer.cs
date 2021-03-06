﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Tienda.Distribucion.Infraestructura.Persistence;

namespace Tienda.WebApp.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20201022211826_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Tienda.Distribucion.Domain.Model.Disitribucion.ItemEntrega", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasColumnName("codigo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnName("descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("OrdenEntregaId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("OrdenEntregaId");

                    b.ToTable("ItemEntregas");
                });

            modelBuilder.Entity("Tienda.Distribucion.Domain.Model.Disitribucion.OrdenEntrega", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Estado")
                        .HasColumnName("estado")
                        .HasColumnType("int");

                    b.Property<DateTime?>("FechaAnulacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("FechaConsolidacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("FechaFinalizacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaRegistro")
                        .HasColumnType("datetime2");

                    b.HasKey("Id")
                        .HasName("ordenEntregaId");

                    b.ToTable("OrdenEntregas");
                });

            modelBuilder.Entity("Tienda.Distribucion.Domain.Model.Disitribucion.SeguimientoViajeItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("FechaHora")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("ViajeId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ViajeId");

                    b.ToTable("SeguimientoViajeItem");
                });

            modelBuilder.Entity("Tienda.Distribucion.Domain.Model.Disitribucion.ViajeEntrega", b =>
                {
                    b.Property<Guid>("ViajeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("FechaFinViaje")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("FechaInicioViaje")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaProgramado")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("OrdenEntregaId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ViajeId");

                    b.HasIndex("OrdenEntregaId");

                    b.ToTable("ViajesEntrega");
                });

            modelBuilder.Entity("Tienda.Distribucion.Domain.Model.Disitribucion.ItemEntrega", b =>
                {
                    b.HasOne("Tienda.Distribucion.Domain.Model.Disitribucion.OrdenEntrega", "OrdenEntrega")
                        .WithMany()
                        .HasForeignKey("OrdenEntregaId");
                });

            modelBuilder.Entity("Tienda.Distribucion.Domain.Model.Disitribucion.OrdenEntrega", b =>
                {
                    b.OwnsOne("Tienda.Distribucion.Domain.ValueObjects.LatitudGps", "LatitudDestino", b1 =>
                        {
                            b1.Property<Guid>("OrdenEntregaId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<decimal>("Value")
                                .HasColumnName("latitud")
                                .HasColumnType("decimal(18,12)");

                            b1.HasKey("OrdenEntregaId");

                            b1.ToTable("OrdenEntregas");

                            b1.WithOwner()
                                .HasForeignKey("OrdenEntregaId");
                        });

                    b.OwnsOne("Tienda.Distribucion.Domain.ValueObjects.LongitudGps", "LongitudDestino", b1 =>
                        {
                            b1.Property<Guid>("OrdenEntregaId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<decimal>("Value")
                                .HasColumnName("longitud")
                                .HasColumnType("decimal(18,12)");

                            b1.HasKey("OrdenEntregaId");

                            b1.ToTable("OrdenEntregas");

                            b1.WithOwner()
                                .HasForeignKey("OrdenEntregaId");
                        });

                    b.OwnsOne("Tienda.SharedKernel.ValueObjects.PersonNameValue", "NombreCliente", b1 =>
                        {
                            b1.Property<Guid>("OrdenEntregaId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnName("nombreCliente")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("OrdenEntregaId");

                            b1.ToTable("OrdenEntregas");

                            b1.WithOwner()
                                .HasForeignKey("OrdenEntregaId");
                        });

                    b.OwnsOne("Tienda.SharedKernel.ValueObjects.PhoneNumber.PhoneNumberValue", "Telefono", b1 =>
                        {
                            b1.Property<Guid>("OrdenEntregaId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnName("telefono")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("OrdenEntregaId");

                            b1.ToTable("OrdenEntregas");

                            b1.WithOwner()
                                .HasForeignKey("OrdenEntregaId");
                        });
                });

            modelBuilder.Entity("Tienda.Distribucion.Domain.Model.Disitribucion.SeguimientoViajeItem", b =>
                {
                    b.HasOne("Tienda.Distribucion.Domain.Model.Disitribucion.ViajeEntrega", "Viaje")
                        .WithMany()
                        .HasForeignKey("ViajeId");

                    b.OwnsOne("Tienda.Distribucion.Domain.ValueObjects.LatitudGps", "Latitud", b1 =>
                        {
                            b1.Property<Guid>("SeguimientoViajeItemId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<decimal>("Value")
                                .HasColumnName("latitud")
                                .HasColumnType("decimal(18,12)");

                            b1.HasKey("SeguimientoViajeItemId");

                            b1.ToTable("SeguimientoViajeItem");

                            b1.WithOwner()
                                .HasForeignKey("SeguimientoViajeItemId");
                        });

                    b.OwnsOne("Tienda.Distribucion.Domain.ValueObjects.LongitudGps", "Longitud", b1 =>
                        {
                            b1.Property<Guid>("SeguimientoViajeItemId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<decimal>("Value")
                                .HasColumnName("longitud")
                                .HasColumnType("decimal(18,12)");

                            b1.HasKey("SeguimientoViajeItemId");

                            b1.ToTable("SeguimientoViajeItem");

                            b1.WithOwner()
                                .HasForeignKey("SeguimientoViajeItemId");
                        });
                });

            modelBuilder.Entity("Tienda.Distribucion.Domain.Model.Disitribucion.ViajeEntrega", b =>
                {
                    b.HasOne("Tienda.Distribucion.Domain.Model.Disitribucion.OrdenEntrega", "OrdenEntrega")
                        .WithMany()
                        .HasForeignKey("OrdenEntregaId");
                });
#pragma warning restore 612, 618
        }
    }
}
