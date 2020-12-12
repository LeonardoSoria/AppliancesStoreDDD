using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using Tienda.Distribucion.Applicacion.DTO;

namespace Tienda.Distribucion.Applicacion.Features.OrdenEntrega.GetAllOrdenEntrega
{
    public class GetAllOrdenEntregaQuery : IRequest<List<OrdenEntregaDTO>>
    {

    }
}
