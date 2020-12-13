using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Tienda.Distribucion.Applicacion.Features.OrdenEntrega.IniciarViaje;
using Tienda.Distribucion.Applicacion.Persistence;
using Tienda.Distribucion.Applicacion.Persistence.Reporsitory;

namespace Tienda.Distribucion.Applicacion.Features.OrdenEntrega.IniciarViajeEntrega
{
    public class IniciarViajeEntregaHandler : IRequestHandler<IniciarViajeEntregaCommand, VoidResult>
    {
        private readonly IOrdenEntregaRepository _ordenEntregaRepository;
        private readonly IUnitOfWork _unitOfWork;


        public IniciarViajeEntregaHandler(IOrdenEntregaRepository ordenEntregaRepository, IUnitOfWork unitOfWork)
        {
            _ordenEntregaRepository = ordenEntregaRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<VoidResult> Handle(IniciarViajeEntregaCommand request, CancellationToken cancellationToken)
        {
            await _ordenEntregaRepository.IniciarViajeEntrega(request.cambiarFecha.Id);
            await _unitOfWork.Commit(cancellationToken);
            return new VoidResult();
        }
    }
}
