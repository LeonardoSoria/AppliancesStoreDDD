using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using Tienda.Distribucion.Applicacion.DTO;

namespace Tienda.Distribucion.Applicacion.Features.OrdenEntrega.IniciarViaje
{
    public class IniciarViajeEntregaCommand : IRequest<VoidResult>
    {
        public CambiarFechaViajeEntregaDTO cambiarFecha { get; set; }

        public IniciarViajeEntregaCommand(CambiarFechaViajeEntregaDTO cambiarFecha)
        {
            this.cambiarFecha = cambiarFecha;
        }
    }
}
