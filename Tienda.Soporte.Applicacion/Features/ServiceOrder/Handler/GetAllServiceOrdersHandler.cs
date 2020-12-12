using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Tienda.Soporte.Applicacion.Features.ServiceOrder.Query;
using Tienda.Soporte.Domain.Model.Soporte;
using Tienda.Soporte.Domain.Persistence;
using Tienda.Soporte.Domain.Persistence.Repository;
using Tienda.Soporte.Infraestructura.DTO;

namespace Tienda.Soporte.Applicacion.Features.ServiceOrder.Handler
{
    public class GetAllServiceOrdersHandler : IRequestHandler<GetAllServiceOrdersQuery, List<ServiceOrderHasProductsDTO>>
    {
        private readonly IServiceOrderRepository _serviceOrderRepository;

        public GetAllServiceOrdersHandler(IServiceOrderRepository serviceOrderRepository)
        {
            _serviceOrderRepository = serviceOrderRepository;
        }

        public async Task<List<ServiceOrderHasProductsDTO>> Handle(GetAllServiceOrdersQuery request, 
            CancellationToken cancellationToken)
        {
            List<ServiceOrderHasProducts> serviceOrderList = await _serviceOrderRepository.GetServiceOrders();
            List<ServiceOrderHasProductsDTO> listResult = new List<ServiceOrderHasProductsDTO>();
            foreach (var item in serviceOrderList)
            {
                listResult.Add(new ServiceOrderHasProductsDTO()
                {
                    ServiceOrdersHasProductsId = item.ServiceOrdersHasProductsId,
                    ServiceOrder = new ServiceOrderDTO(item.ServiceOrder.ServiceOrderId, item.ServiceOrder.CreationDate, 
                        new ClientDTO(item.ServiceOrder.Client.ClientId, item.ServiceOrder.Client.Name,
                        item.ServiceOrder.Client.Lastname,item.ServiceOrder.Client.Phone, item.ServiceOrder.Client.Email, 
                        item.ServiceOrder.Client.Address), item.ServiceOrder.Status),
                    Product = new ProductDTO(item.Product.ProductId, item.Product.ProductBrand, item.Product.ProductName, 
                        item.Product.ProductPrice)
                });
            }
            return listResult;
        }
    }
}
