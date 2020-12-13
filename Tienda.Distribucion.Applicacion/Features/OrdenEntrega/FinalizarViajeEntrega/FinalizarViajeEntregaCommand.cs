using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using Tienda.Distribucion.Applicacion.DTO;

namespace Tienda.Distribucion.Applicacion.Features.OrdenEntrega.FinalizarViajeEntrega
{
    public class FinalizarViajeEntregaCommand : IRequest<VoidResult>
    {
        public CambiarFechaViajeEntregaDTO cambiarFecha { get; set; }

        public FinalizarViajeEntregaCommand(CambiarFechaViajeEntregaDTO cambiarFecha)
        {
            this.cambiarFecha = cambiarFecha;
        }
    }
}
