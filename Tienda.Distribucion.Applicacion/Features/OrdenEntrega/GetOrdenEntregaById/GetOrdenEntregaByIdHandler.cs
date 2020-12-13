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

            List<Tienda.Distribucion.Domain.Model.Disitribucion.ViajeEntrega> viajesEntrega
                = await _ordenEntregaRepository.GetViajeEntregaByOrdenEntregaId(request.Id);

            List<Tienda.Distribucion.Domain.Model.Disitribucion.ItemEntrega> itemsEntrega
                = await _ordenEntregaRepository.GetItemEntregaByOrdenEntregaId(request.Id);

            List<ViajeEntregaDTO> viajeEntregaList = new List<ViajeEntregaDTO>();
            List<ItemEntregaDTO> itemEntregaList = new List<ItemEntregaDTO>();

            foreach (var item in viajesEntrega)
            {
                viajeEntregaList.Add(new ViajeEntregaDTO()
                {
                    Id = item.ViajeId,
                    FechaProgramado = item.FechaProgramado,
                    FechaInicioViaje = item.FechaInicioViaje,
                    FechaFinViaje = item.FechaFinViaje
                });
            }

            foreach (var item in itemsEntrega)
            {
                itemEntregaList.Add(new ItemEntregaDTO()
                {
                    Codigo = item.Codigo,
                    Descripcion = item.Descripcion
                });
            }

            return new OrdenEntregaDTO()
            {
                Id = ordenEntrega.Id,
                LatitudDestino = ordenEntrega.LatitudDestino,
                LongitudDestino = ordenEntrega.LongitudDestino,
                NombreCliente = ordenEntrega.NombreCliente,
                Telefono = ordenEntrega.Telefono,
                Estado = ordenEntrega.Estado,
                Viajes = viajeEntregaList,
                Items = itemEntregaList
            };
        }
    }
}
