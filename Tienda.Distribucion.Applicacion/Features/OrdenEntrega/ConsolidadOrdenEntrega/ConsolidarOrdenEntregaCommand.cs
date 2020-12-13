using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using Tienda.Distribucion.Applicacion.DTO;

namespace Tienda.Distribucion.Applicacion.Features.OrdenEntrega.ConsolidadOrdenEntrega
{
    public class ConsolidarOrdenEntregaCommand : IRequest<VoidResult>
    {
        public ViajeEntregaDTO ViajeEntrega { get; set; }

        public ConsolidarOrdenEntregaCommand(ViajeEntregaDTO viajeEntrega)
        {
            ViajeEntrega = viajeEntrega;
        }
    }
}
