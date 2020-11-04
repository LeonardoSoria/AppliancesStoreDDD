using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Tienda.Soporte.Domain.Model;
using Tienda.Soporte.Domain.Model.Soporte;

namespace Tienda.Soporte.Infraestructura.EntityConfiguration
{
    public class ServiceOrderEntityTypeConfiguration : IEntityTypeConfiguration<ServiceOrder>
    {
        public void Configure(EntityTypeBuilder<ServiceOrder> builder)
        {
            builder.HasKey(x => x.ServiceOrderId).HasName("serviceOrderId");

            builder.Property(x => x.CreationDate).HasColumnName("serviceOrderCreationDate").IsRequired();

            builder.Property(x => x.Status).HasColumnName("serviceOrderStatus").IsRequired();

        }
    }
}
