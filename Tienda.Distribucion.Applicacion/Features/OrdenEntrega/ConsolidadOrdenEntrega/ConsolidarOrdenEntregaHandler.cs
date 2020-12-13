using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Tienda.Distribucion.Applicacion.Persistence;
using Tienda.Distribucion.Applicacion.Persistence.Reporsitory;

namespace Tienda.Distribucion.Applicacion.Features.OrdenEntrega.ConsolidadOrdenEntrega
{
    public class ConsolidarOrdenEntregaHandler : IRequestHandler<ConsolidarOrdenEntregaCommand, VoidResult>
    {
        private readonly IOrdenEntregaRepository _ordenEntregaRepository;
        private readonly IUnitOfWork _unitOfWork;


        public ConsolidarOrdenEntregaHandler(IOrdenEntregaRepository ordenEntregaRepository, IUnitOfWork unitOfWork)
        {
            _ordenEntregaRepository = ordenEntregaRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<VoidResult> Handle(ConsolidarOrdenEntregaCommand request, CancellationToken cancellationToken)
        {
            Domain.Model.Disitribucion.ViajeEntrega objViajeEntrega = new Domain.Model.Disitribucion.ViajeEntrega(
                    new Domain.Model.Disitribucion.OrdenEntrega(request.ViajeEntrega.OrdenEntrega.Id),
                    request.ViajeEntrega.FechaProgramado);

            await _ordenEntregaRepository.ConsolidarEntrega(request.ViajeEntrega.OrdenEntrega.Id, objViajeEntrega);
            await _unitOfWork.Commit(cancellationToken);
            return new VoidResult();
        }
    }
}
