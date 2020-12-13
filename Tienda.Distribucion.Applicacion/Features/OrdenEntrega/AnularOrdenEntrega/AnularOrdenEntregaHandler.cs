using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Tienda.Distribucion.Applicacion.Persistence;
using Tienda.Distribucion.Applicacion.Persistence.Reporsitory;

namespace Tienda.Distribucion.Applicacion.Features.OrdenEntrega.CancelarOrdenEntrega
{
    public class AnularOrdenEntregaHandler : IRequestHandler<AnularOrdenEntregaCommand, VoidResult>
    {
        private readonly IOrdenEntregaRepository _ordenEntregaRepository;
        private readonly IUnitOfWork _unitOfWork;


        public AnularOrdenEntregaHandler(IOrdenEntregaRepository ordenEntregaRepository, IUnitOfWork unitOfWork)
        {
            _ordenEntregaRepository = ordenEntregaRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<VoidResult> Handle(AnularOrdenEntregaCommand request, CancellationToken cancellationToken)
        {
            await _ordenEntregaRepository.AnularEntrega(request.cambiarEstado.Id);
            await _unitOfWork.Commit(cancellationToken);
            return new VoidResult();
        }
    }
}
