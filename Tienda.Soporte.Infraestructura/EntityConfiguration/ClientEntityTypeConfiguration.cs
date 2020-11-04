using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Tienda.Soporte.Domain.Model.Soporte;

namespace Tienda.Soporte.Infraestructura.EntityConfiguration
{
    public class ClientEntityTypeConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.HasKey(x => x.ClientId).HasName("clientId");

            builder.Property(x => x.Address).HasColumnName("clientAddress").IsRequired();

            builder.OwnsOne(x => x.Name).Property(x => x.Value).HasColumnName("clientName").IsRequired();

            builder.OwnsOne(x => x.Lastname).Property(x => x.Value).HasColumnName("clientLastname").IsRequired();

            builder.OwnsOne(x => x.Phone).Property(x => x.Value).HasColumnName("clientPhone").IsRequired();

            builder.OwnsOne(x => x.Email).Property(x => x.Value).HasColumnName("clientEmail").IsRequired();

        }
    }
}
