using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using Tienda.Distribucion.Applicacion.DTO;

namespace Tienda.Distribucion.Applicacion.Features.OrdenEntrega.CancelarOrdenEntrega
{
    public class AnularOrdenEntregaCommand : IRequest<VoidResult>
    {
        public CambiarEstadoOrdenEntregaDTO cambiarEstado { get; set; }

        public AnularOrdenEntregaCommand(CambiarEstadoOrdenEntregaDTO cambiarEstado)
        {
            this.cambiarEstado = cambiarEstado;
        }
    }
}
