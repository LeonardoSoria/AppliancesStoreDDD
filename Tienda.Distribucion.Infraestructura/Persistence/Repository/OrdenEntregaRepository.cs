using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tienda.Distribucion.Domain.Model.Disitribucion;
using Tienda.Distribucion.Domain.Persistence.Reporsitory;
using Tienda.Distribucion.Infraestructura.Persistence;

namespace Tienda.Distribucion.Infraestructura.Repository
{
    public class OrdenEntregaRepository : IOrdenEntregaRepository
    {
        private readonly ApplicationDbContext _context;

        public OrdenEntregaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<OrdenEntrega> GetOrdenEntregaById(Guid ordenEntregaId)
        {
            OrdenEntrega obj = 
                await _context.OrdenEntregas.Where(o => o.Id == ordenEntregaId).FirstOrDefaultAsync();
            return obj;
        }

        public async Task Insert(OrdenEntrega ordenEntrega)
        {
            await _context.OrdenEntregas.AddAsync(ordenEntrega);

            foreach (var item in ordenEntrega.Items)
            {
                await _context.ItemEntregas.AddAsync(item);
            }
            
        }
    }
}
