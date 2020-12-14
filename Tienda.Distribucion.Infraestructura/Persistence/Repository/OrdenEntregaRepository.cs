using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tienda.Distribucion.Applicacion.Persistence.Reporsitory;
using Tienda.Distribucion.Domain.Model.Disitribucion;
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

        public async Task<List<OrdenEntrega>> GetAllOrdenEntrega()
        {
            List<OrdenEntrega> result =
                await _context.OrdenEntregas.ToListAsync();
            return result;
        }

        public async Task<OrdenEntrega> GetOrdenEntregaById(Guid ordenEntregaId)
        {
            OrdenEntrega obj =
                await _context.OrdenEntregas.Where(o => o.Id == ordenEntregaId).FirstOrDefaultAsync();
            return obj;
        }

        public async Task ConsolidarEntrega(Guid ordenEntregaId, ViajeEntrega viajeEntrega)
        {
            OrdenEntrega obj =
                await _context.OrdenEntregas.Where(o => o.Id == ordenEntregaId).FirstOrDefaultAsync();
            ViajeEntrega objViaje = new ViajeEntrega(obj, viajeEntrega.FechaProgramado);
            await _context.ViajesEntrega.AddAsync(objViaje);
            obj.ConsolidarOrdenEntrega();
        }

        public async Task FinalizarEntrega(Guid ordenEntregaId)
        {
            OrdenEntrega obj =
                await _context.OrdenEntregas.Where(o => o.Id == ordenEntregaId).FirstOrDefaultAsync();
            obj.FinalizarEntrega();
        }

        public async Task AnularEntrega(Guid ordenEntregaId)
        {
            OrdenEntrega obj =
                await _context.OrdenEntregas.Where(o => o.Id == ordenEntregaId).FirstOrDefaultAsync();
            obj.AnularEntrega();
        }

        public async Task Insert(OrdenEntrega ordenEntrega)
        {
            await _context.OrdenEntregas.AddAsync(ordenEntrega);

            foreach (var item in ordenEntrega.Items)
            {
                await _context.ItemEntregas.AddAsync(item);
            }
        }

        public async Task<List<ViajeEntrega>> GetViajeEntregaByOrdenEntregaId(Guid ordenEntregaId)
        {
            List<ViajeEntrega> result =
                await _context.ViajesEntrega.Where(x => x.OrdenEntrega.Id == ordenEntregaId).ToListAsync();
            return result;
        }

        public async Task<List<ItemEntrega>> GetItemEntregaByOrdenEntregaId(Guid ordenEntregaId)
        {
            List<ItemEntrega> result =
                await _context.ItemEntregas.Where(x => x.OrdenEntrega.Id == ordenEntregaId).ToListAsync();
            return result;
        }

        public async Task IniciarViajeEntrega(Guid viajeEntregaId)
        {
            ViajeEntrega obj =
                await _context.ViajesEntrega.Where(o => o.ViajeId == viajeEntregaId).FirstOrDefaultAsync();
            obj.IniciarViajeEntrega();
        }

        public async Task FinalizarViajeEntrega(Guid viajeEntregaId)
        {
            ViajeEntrega obj =
                await _context.ViajesEntrega.Where(o => o.ViajeId == viajeEntregaId).FirstOrDefaultAsync();
            obj.FinalizarViajeEntrega();
        }

        public async Task InsertarSeguimientoViajeItem(Guid viajeEntregaId, SeguimientoViajeItem seguimientoViajeItem)
        {
            ViajeEntrega obj =
                await _context.ViajesEntrega.Where(o => o.ViajeId == viajeEntregaId).FirstOrDefaultAsync();
            
            SeguimientoViajeItem objSeguimientoViajeItem = new SeguimientoViajeItem(
                seguimientoViajeItem.Latitud, seguimientoViajeItem.Longitud, obj);

            await _context.SeguimientoViajeItem.AddAsync(objSeguimientoViajeItem);
        }
    }
}
