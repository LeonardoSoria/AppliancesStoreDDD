using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Tienda.Distribucion.Applicacion.Persistence;
using Tienda.Distribucion.Applicacion.Persistence.Reporsitory;

namespace Tienda.Distribucion.Applicacion.Features.OrdenEntrega.InsertOrdenEntrega
{
    public class InsertOrdenEntregaHandler : IRequestHandler<InsertOrdenEntregaCommand, VoidResult>
    {
        private readonly IOrdenEntregaRepository _ordenEntregaRepository;
        private readonly IUnitOfWork _unitOfWork;


        public InsertOrdenEntregaHandler(IOrdenEntregaRepository ordenEntregaRepository, IUnitOfWork unitOfWork)
        {
            _ordenEntregaRepository = ordenEntregaRepository;
            _unitOfWork = unitOfWork;
        }


        public async Task<VoidResult> Handle(InsertOrdenEntregaCommand request, CancellationToken cancellationToken)
        {
            Dictionary<string, string> items = new Dictionary<string, string>();
            foreach (var item in request.Items)
            {
                items.Add(item.Codigo, item.Descripcion);
            }

            Domain.Model.Disitribucion.OrdenEntrega obj = new
                Domain.Model.Disitribucion.OrdenEntrega(request.NombreCliente,
                request.Telefono,
                request.LatitudDestino,
                request.LongitudDestino,
                items
                );

            await _ordenEntregaRepository.Insert(obj);

            await _unitOfWork.Commit(cancellationToken);

            return new VoidResult();
        }
    }
}
