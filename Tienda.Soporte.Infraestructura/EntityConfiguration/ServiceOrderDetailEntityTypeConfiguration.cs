using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Tienda.Soporte.Domain.Model.Soporte;

namespace Tienda.Soporte.Infraestructura.EntityConfiguration
{
    public class ServiceOrderDetailEntityTypeConfiguration : IEntityTypeConfiguration<ServiceOrderDetail>
    {
        public void Configure(EntityTypeBuilder<ServiceOrderDetail> builder)
        {
            builder.HasKey(x => x.ServiceOrderDetailId).HasName("serviceOrderDetailId");

            builder.Property(x => x.ServiceType).HasColumnName("serviceOrderDetailType").IsRequired();

            builder.Property(x => x.Price).HasColumnName("serviceOrderDetailPrice").HasColumnType("decimal(5,2)").IsRequired();

            builder.Property(x => x.Description).HasColumnName("serviceOrderDetailDescription").IsRequired();

            builder.Property(x => x.AlternativeAddress).HasColumnName("serviceOrderDetailAlternativeAddress").IsRequired();

        }
    }
}
