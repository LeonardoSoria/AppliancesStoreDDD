using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Tienda.Soporte.Domain.Model.Soporte;

namespace Tienda.Soporte.Infraestructura.EntityConfiguration
{
    class JobFormEntityTypeConfiguration : IEntityTypeConfiguration<JobForm>
    {
        public void Configure(EntityTypeBuilder<JobForm> builder)
        {
            builder.HasKey(x => x.JobFormId).HasName("jobFormId");

            builder.Property(x => x.Detail).HasColumnName("jobFormDetail").IsRequired();

            builder.Property(x => x.Date).HasColumnName("jobFormDate").IsRequired();
        }
    }
}
