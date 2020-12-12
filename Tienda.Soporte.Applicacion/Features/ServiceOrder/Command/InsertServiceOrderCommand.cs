using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using Tienda.Soporte.Infraestructura.DTO;
using Tienda.Soporte.Infraestructura.Features;

namespace Tienda.Soporte.Applicacion.Features.ServiceOrder.Command
{
    public class InsertServiceOrderCommand : IRequest<VoidResult>
    {
        public ServiceOrderDetailDTO ServiceOrderDetail { get; set; }

        public InsertServiceOrderCommand(ServiceOrderDetailDTO serviceOrderDetail)
        {
            ServiceOrderDetail = serviceOrderDetail;
        }
    }
}
