using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using Tienda.Distribucion.Applicacion.DTO;

namespace Tienda.Distribucion.Applicacion.Features.OrdenEntrega.InsertarSeguimientoViajeItem
{
    public class InsertarSeguimientoVIajeItemCommand : IRequest<VoidResult>
    {
        public SeguimientoViajeItemDTO Seguimiento{ get; set; }

        public InsertarSeguimientoVIajeItemCommand(SeguimientoViajeItemDTO seguimiento)
        {
            this.Seguimiento = seguimiento;
        }
    }
}
