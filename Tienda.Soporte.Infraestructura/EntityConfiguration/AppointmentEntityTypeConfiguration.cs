using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Tienda.Soporte.Domain.Model.Soporte;

namespace Tienda.Soporte.Infraestructura.EntityConfiguration
{
    public class AppointmentEntityTypeConfiguration : IEntityTypeConfiguration<Appointment>
    {
        public void Configure(EntityTypeBuilder<Appointment> builder)
        {
            builder.HasKey(x => x.AppointmentId).HasName("appointmentId");

            builder.Property(x => x.Status).HasColumnName("appointmentStatus").IsRequired();

            builder.Property(x => x.VisitDate).HasColumnName("appointmentVisitDate").IsRequired();

        }
    }
}
