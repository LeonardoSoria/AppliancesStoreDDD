using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using Tienda.Soporte.Domain.Model.Soporte;
using Tienda.Soporte.Infraestructura.EntityConfiguration;

namespace Tienda.Soporte.Infraestructura.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Client> Clients { get; private set; }
        public DbSet<Product> Products { get; private set; }
        public DbSet<ServiceOrder> ServiceOrders { get; private set; }
        public DbSet<ServiceOrderHasProducts> ServiceOrderHasProducts { get; private set; }
        public DbSet<ServiceOrderDetail> ServiceOrdersDetails { get; private set; }
        public DbSet<Appointment> Appointments { get; private set; }
        public DbSet<Technician> Technicians { get; private set; }
        public DbSet<AppointmentHasTechnician> AppointmentHasTechnicians { get; private set; }
        public DbSet<JobForm> JobForms { get; private set; }

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new ClientEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ProductEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ServiceOrderEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ServiceOrderHasProductsEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ServiceOrderDetailEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new AppointmentEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new TechnicianEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new AppointmentHasTechnicianEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new JobFormEntityTypeConfiguration());
            //
        }
    }
}
