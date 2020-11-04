using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Tienda.Distribucion.Domain.Model.Disitribucion;

namespace Tienda.Distribucion.Infraestructura.EntityConfiguration
{
    public class OrdenEntregaEntityTypeConfiguration :
        IEntityTypeConfiguration<OrdenEntrega>
    {
        public void Configure(EntityTypeBuilder<OrdenEntrega> builder)
        {
            builder
                .HasKey(x => x.Id)
                .HasName("ordenEntregaId");

            builder.Property(x => x.FechaRegistro)
                .IsRequired();

            builder.Property(x => x.Estado)
                .HasColumnName("estado")
                .IsRequired();

            builder.OwnsOne(x => x.NombreCliente)
                .Property(x => x.Value)
                .HasColumnName("nombreCliente")
                .IsRequired();

            builder.OwnsOne(x => x.Telefono)
                .Property(x => x.Value)
                .HasColumnName("telefono")
                .IsRequired();

            builder.OwnsOne(x => x.LatitudDestino)
                .Property(y => y.Value)
                .HasColumnName("latitud")
                .HasColumnType("decimal(18,12)")
                .IsRequired();

            builder.OwnsOne(x => x.LongitudDestino)
                .Property(y => y.Value)
                .HasColumnName("longitud")
                .HasColumnType("decimal(18,12)")
                .IsRequired();

            builder.Ignore(x => x.Viajes);

            builder.Ignore(x => x.Items);
            /*
             * 
              public EstadoOrdenEntrega Estado { get; private set; }
        public PersonNameValue NombreCliente { get; private set; }
        public PhoneNumberValue Telefono { get; private set; }

        public LatitudGps LatitudDestino { get; private set; }
        public LongitudGps LongitudGps { get; private set; }
             */
        }
    }
}
