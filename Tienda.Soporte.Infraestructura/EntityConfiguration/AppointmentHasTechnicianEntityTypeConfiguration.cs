using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Tienda.Soporte.Domain.Model.Soporte;

namespace Tienda.Soporte.Infraestructura.EntityConfiguration
{
    public class AppointmentHasTechnicianEntityTypeConfiguration : IEntityTypeConfiguration<AppointmentHasTechnician>
    {
        public void Configure(EntityTypeBuilder<AppointmentHasTechnician> builder)
        {
            builder.HasKey(x => x.AppoinmtentHasTechnicianId).HasName("appointmentHasTechnicianId");
        }
    }
}
