using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Tienda.Distribucion.Domain.Model.Disitribucion;

namespace Tienda.Distribucion.Infraestructura.EntityConfiguration
{
    public class ItemEntregaEntityTypeConfiguration
        : IEntityTypeConfiguration<ItemEntrega>
    {
        public void Configure(EntityTypeBuilder<ItemEntrega> builder)
        {
            builder.HasKey(x => x.Id);


            builder.Property(x => x.Codigo)
                .HasColumnName("codigo")
                .IsRequired();

            builder.Property(x => x.Descripcion)
               .HasColumnName("descripcion")
               .IsRequired();
        }
    }
}
