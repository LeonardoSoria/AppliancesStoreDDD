using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tienda.Distribucion.Domain.Model.Disitribucion;

namespace Tienda.Distribucion.Domain.Persistence.Reporsitory
{
    public interface IOrdenEntregaRepository
    {
        Task Insert(OrdenEntrega ordenEntrega);

        Task<OrdenEntrega> GetOrdenEntregaById(Guid ordenEntregaId);
    }
}
