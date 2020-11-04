using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Tienda.Soporte.Domain.Model.Soporte;

namespace Tienda.Soporte.Infraestructura.EntityConfiguration
{
    class ServiceOrderHasProductsEntityTypeConfiguration : IEntityTypeConfiguration<ServiceOrderHasProducts>
    {
        public void Configure(EntityTypeBuilder<ServiceOrderHasProducts> builder)
        {
            builder.HasKey(x => x.ServiceOrdersHasProductsId).HasName("serviceOrderHasProductsId");
        }
    }
}
