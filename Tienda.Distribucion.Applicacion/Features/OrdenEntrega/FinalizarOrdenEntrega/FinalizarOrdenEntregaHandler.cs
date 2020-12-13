using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Tienda.Distribucion.Applicacion.Features.OrdenEntrega.CancelarOrdenEntrega;
using Tienda.Distribucion.Applicacion.Persistence;
using Tienda.Distribucion.Applicacion.Persistence.Reporsitory;

namespace Tienda.Distribucion.Applicacion.Features.OrdenEntrega.FinalizarOrdenEntrega
{
    public class FinalizarOrdenEntregaHandler : IRequestHandler<FinalizarOrdenEntregaCommand, VoidResult>
    {
        private readonly IOrdenEntregaRepository _ordenEntregaRepository;
        private readonly IUnitOfWork _unitOfWork;


        public FinalizarOrdenEntregaHandler(IOrdenEntregaRepository ordenEntregaRepository, IUnitOfWork unitOfWork)
        {
            _ordenEntregaRepository = ordenEntregaRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<VoidResult> Handle(FinalizarOrdenEntregaCommand request, CancellationToken cancellationToken)
        {
            await _ordenEntregaRepository.FinalizarEntrega(request.cambiarEstado.Id);
            await _unitOfWork.Commit(cancellationToken);
            return new VoidResult();
        }
    }
}
