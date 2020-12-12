using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tienda.Soporte.Domain.Model.Soporte;

namespace Tienda.Soporte.Domain.Persistence.Repository
{
    public interface IServiceOrderRepository
    {
        Task<ServiceOrder> Insert(ServiceOrder serviceOrder);

        Task InsertDetail(ServiceOrderDetail serviceOrderDetails);

        Task InsertProducts(ServiceOrder serviceOrder, Product product);

        Task<List<ServiceOrderHasProducts>> GetServiceOrderById(Guid serviceOrderId);

        Task<List<ServiceOrderHasProducts>> GetServiceOrders();

        Task CancelServiceOrder(Guid serviceOrderId);
    }
}
