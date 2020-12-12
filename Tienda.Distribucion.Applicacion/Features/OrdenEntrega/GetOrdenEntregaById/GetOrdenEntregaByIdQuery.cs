using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tienda.Distribucion.Applicacion.DTO;

namespace Tienda.Distribucion.Applicacion.Features.OrdenEntrega.GetOrdenEntregaById
{
    public class GetOrdenEntregaByIdQuery : IRequest<OrdenEntregaDTO>
    {
        public Guid Id { get; set; }

        public GetOrdenEntregaByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
