using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Tienda.Distribucion.Applicacion.DTO;
using Tienda.Distribucion.Applicacion.Persistence.Reporsitory;

namespace Tienda.Distribucion.Applicacion.Features.OrdenEntrega.GetOrdenEntregaById
{
    public class GetOrdenEntregaByIdHandler : IRequestHandler<GetOrdenEntregaByIdQuery, OrdenEntregaDTO>
    {
        private readonly IOrdenEntregaRepository _ordenEntregaRepository;

        public GetOrdenEntregaByIdHandler(IOrdenEntregaRepository ordenEntregaRepository)
        {
            _ordenEntregaRepository = ordenEntregaRepository;
        }

        public async Task<OrdenEntregaDTO> Handle(GetOrdenEntregaByIdQuery request, CancellationToken cancellationToken)
        {
            Tienda.Distribucion.Domain.Model.Disitribucion.OrdenEntrega ordenEntrega
                = await _ordenEntregaRepository.GetOrdenEntregaById(request.Id);

            return new OrdenEntregaDTO()
            {
                Id = ordenEntrega.Id,
                LatitudDestino = ordenEntrega.LatitudDestino,
                LongitudDestino = ordenEntrega.LongitudDestino,
                NombreCliente = ordenEntrega.NombreCliente,
                Telefono = ordenEntrega.Telefono
            };
        }
    }
}
