using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Tienda.Distribucion.Domain.Model.Disitribucion;

namespace Tienda.Distribucion.Infraestructura.EntityConfiguration
{
    public class ViajeEntregaEntityTypeConfiguration :
        IEntityTypeConfiguration<ViajeEntrega>
    {
        public void Configure(EntityTypeBuilder<ViajeEntrega> builder)
        {
            builder.HasKey(x => x.ViajeId);

            builder.Property(x => x.FechaProgramado)
                .IsRequired();

            builder.Ignore(x => x.ItemsSeguimiento);
        }
    }
}
