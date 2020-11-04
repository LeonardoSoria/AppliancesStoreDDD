using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using Tienda.Distribucion.Domain.Model.Disitribucion;
using Tienda.Distribucion.Infraestructura.EntityConfiguration;

namespace Tienda.Distribucion.Infraestructura.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<OrdenEntrega> OrdenEntregas { get; private set; }
        public DbSet<ViajeEntrega> ViajesEntrega { get; private set; }
        public DbSet<SeguimientoViajeItem> SeguimientoViajeItem { get; private set; }
        public DbSet<ItemEntrega> ItemEntregas { get; private set; }

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new OrdenEntregaEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ItemEntregaEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ViajeEntregaEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new SeguimientoViajeItemEntityTypeConfiguration());
            //
        }
    }
}
