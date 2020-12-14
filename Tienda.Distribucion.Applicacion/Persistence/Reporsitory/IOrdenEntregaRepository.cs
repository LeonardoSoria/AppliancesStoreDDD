using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tienda.Distribucion.Domain.Model.Disitribucion;

namespace Tienda.Distribucion.Applicacion.Persistence.Reporsitory
{
    public interface IOrdenEntregaRepository
    {
        Task Insert(OrdenEntrega ordenEntrega);

        Task<OrdenEntrega> GetOrdenEntregaById(Guid ordenEntregaId);

        Task ConsolidarEntrega(Guid ordenEntregaId, ViajeEntrega viajeEntrega);

        Task InsertarSeguimientoViajeItem(Guid viajeEntregaId, SeguimientoViajeItem seguimientoViajeItem);

        Task FinalizarEntrega(Guid ordenEntregaId);

        Task AnularEntrega(Guid ordenEntregaId);

        Task IniciarViajeEntrega(Guid viajeEntregaId);

        Task FinalizarViajeEntrega(Guid viajeEntregaId);

        Task<List<OrdenEntrega>> GetAllOrdenEntrega();

        Task<List<ItemEntrega>> GetItemEntregaByOrdenEntregaId(Guid ordenEntregaId);

        Task<List<ViajeEntrega>> GetViajeEntregaByOrdenEntregaId(Guid ordenEntregaId);
    }
}
