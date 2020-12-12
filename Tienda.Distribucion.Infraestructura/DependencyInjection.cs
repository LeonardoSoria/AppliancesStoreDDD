using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Tienda.Distribucion.Applicacion.Persistence;
using Tienda.Distribucion.Applicacion.Persistence.Reporsitory;
using Tienda.Distribucion.Infraestructura.Persistence;
using Tienda.Distribucion.Infraestructura.Repository;

namespace Tienda.Distribucion.Infraestructura
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services, IConfiguration configuration
            )
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                   options.UseSqlServer(
                   configuration.GetConnectionString("DBConnectionString"),
                   b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));


            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IOrdenEntregaRepository, OrdenEntregaRepository>();

            return services;
        }
    }
}
