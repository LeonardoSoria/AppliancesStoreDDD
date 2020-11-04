using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Tienda.Soporte.Domain.Model.Soporte;

namespace Tienda.Soporte.Infraestructura.EntityConfiguration
{
    public class TechnicianEntityTypeConfiguration : IEntityTypeConfiguration<Technician>
    {
        public void Configure(EntityTypeBuilder<Technician> builder)
        {
            builder.HasKey(x => x.TechnicianId).HasName("technicianId");

            builder.Property(x => x.CI).HasColumnName("technicianCI").IsRequired();

            builder.OwnsOne(x => x.Name).Property(x => x.Value).HasColumnName("technicianName").IsRequired();

            builder.OwnsOne(x => x.Lastname).Property(x => x.Value).HasColumnName("technicianLastname").IsRequired();

            builder.OwnsOne(x => x.Phone).Property(x => x.Value).HasColumnName("technicianPhone").IsRequired();

            builder.OwnsOne(x => x.Email).Property(x => x.Value).HasColumnName("technicianEmail").IsRequired();
        }
    }
}
