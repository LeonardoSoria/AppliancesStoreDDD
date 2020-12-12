using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Tienda.Soporte.Applicacion.Features.ServiceOrder.Command;
using Tienda.Soporte.Domain.Model.Soporte;
using Tienda.Soporte.Domain.Persistence;
using Tienda.Soporte.Domain.Persistence.Repository;
using Tienda.Soporte.Infraestructura.DTO;
using Tienda.Soporte.Infraestructura.Features;

namespace Tienda.Soporte.Applicacion.Features.ServiceOrder
{
    public class InsertServiceOrderHandler : IRequestHandler<InsertServiceOrderCommand, VoidResult>
    {
        private readonly IServiceOrderRepository _serviceOrderRepository;
        private readonly IUnitOfWork _unitOfWork;

        public InsertServiceOrderHandler(IUnitOfWork unitOfWork, IServiceOrderRepository serviceOrderRepository)
        {
            _unitOfWork = unitOfWork;
            _serviceOrderRepository = serviceOrderRepository;
        }

        public async Task<VoidResult> Handle(InsertServiceOrderCommand request, CancellationToken cancellationToken)
        {
            Domain.Model.Soporte.ServiceOrder objServiceOrder = await _serviceOrderRepository.Insert(
                    new Domain.Model.Soporte.ServiceOrder(
                        new Client(request.ServiceOrderDetail.ServiceOrder.Client.Id)));

            await _serviceOrderRepository.InsertDetail(
                new ServiceOrderDetail((ServiceTypeEnum)request.ServiceOrderDetail.ServiceType,
                request.ServiceOrderDetail.Price, objServiceOrder, request.ServiceOrderDetail.Description, 
                request.ServiceOrderDetail.AlternativeAddress));

            foreach (ProductDTO product in request.ServiceOrderDetail.Products)
            {
                await _serviceOrderRepository.InsertProducts(objServiceOrder, new Product(product.Id));
            }

            await _unitOfWork.Commit();
            return new VoidResult();
        }
    }
}
