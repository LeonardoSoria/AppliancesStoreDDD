using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Tienda.Distribucion.Applicacion.Persistence;
using Tienda.Distribucion.Applicacion.Persistence.Reporsitory;
using Tienda.Distribucion.Domain.Model.Disitribucion;

namespace Tienda.Distribucion.Applicacion.Features.OrdenEntrega.InsertarSeguimientoViajeItem
{
    public class InsertarSeguimientoViajeItemHandler : IRequestHandler<InsertarSeguimientoVIajeItemCommand, VoidResult>
    {
        private readonly IOrdenEntregaRepository _ordenEntregaRepository;
        private readonly IUnitOfWork _unitOfWork;


        public InsertarSeguimientoViajeItemHandler(IOrdenEntregaRepository ordenEntregaRepository, IUnitOfWork unitOfWork)
        {
            _ordenEntregaRepository = ordenEntregaRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<VoidResult> Handle(InsertarSeguimientoVIajeItemCommand request, CancellationToken cancellationToken)
        {
            SeguimientoViajeItem seguimiento = new SeguimientoViajeItem(request.Seguimiento.Latitud, 
                request.Seguimiento.Longitud);
            await _ordenEntregaRepository.InsertarSeguimientoViajeItem(request.Seguimiento.ViajeEntrega.Id, seguimiento);
            await _unitOfWork.Commit(cancellationToken);
            return new VoidResult();
        }
    }
}
