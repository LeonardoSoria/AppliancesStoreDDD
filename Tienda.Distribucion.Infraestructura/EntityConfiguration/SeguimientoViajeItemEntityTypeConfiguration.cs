using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Tienda.Distribucion.Domain.Model.Disitribucion;

namespace Tienda.Distribucion.Infraestructura.EntityConfiguration
{
    public class SeguimientoViajeItemEntityTypeConfiguration
        : IEntityTypeConfiguration<SeguimientoViajeItem>
    {
        public void Configure(EntityTypeBuilder<SeguimientoViajeItem> builder)
        {
            builder.HasKey(x => x.Id);

            builder.OwnsOne(x => x.Latitud)
                .Property(y => y.Value)
                .IsRequired()
                .HasColumnName("latitud")
                .HasColumnType("decimal(18,12)");


            builder.OwnsOne(x => x.Longitud)
                .Property(y => y.Value)
                .IsRequired()
                .HasColumnName("longitud")
                .HasColumnType("decimal(18,12)");


            //builder.OwnsOne(x => x.Viaje)
            //    .Property(y => y.ViajeId)
            //    .IsRequired()
            //    .HasColumnName("viajeId'");



        }
    }
}
