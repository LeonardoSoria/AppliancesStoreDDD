using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using Tienda.Distribucion.Applicacion.DTO;

namespace Tienda.Distribucion.Applicacion.Features.OrdenEntrega.FinalizarOrdenEntrega
{
    public class FinalizarOrdenEntregaCommand : IRequest<VoidResult>
    {
        public CambiarEstadoOrdenEntregaDTO cambiarEstado { get; set; }

        public FinalizarOrdenEntregaCommand(CambiarEstadoOrdenEntregaDTO cambiarEstado)
        {
            this.cambiarEstado = cambiarEstado;
        }
    }
}
