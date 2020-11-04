using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Tienda.Soporte.Domain.Model.Soporte;

namespace Tienda.Soporte.Infraestructura.EntityConfiguration
{
    public class ProductEntityTypeConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.ProductId).HasName("productId");

            builder.Property(x => x.ProductBrand).HasColumnName("productBrand").IsRequired();

            builder.Property(x => x.ProductName).HasColumnName("productName").IsRequired();

            builder.Property(x => x.ProductPrice).HasColumnName("productPrice").IsRequired();
        }
    }
}
