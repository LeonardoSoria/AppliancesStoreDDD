using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using Tienda.Soporte.Domain.Model.Soporte;
using Tienda.Soporte.Infraestructura.DTO;

namespace Tienda.Soporte.Applicacion.Features.ServiceOrder.Query
{
    public class GetAllServiceOrdersQuery : IRequest<List<ServiceOrderHasProductsDTO>>
    {
    }
}
