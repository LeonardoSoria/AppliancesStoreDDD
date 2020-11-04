using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tienda.Soporte.Domain.Model.Soporte;
using Tienda.Soporte.Domain.Persistence.Repository;

namespace Tienda.Soporte.Infraestructura.Persistence.Repository
{
    public class ServiceOrderRepository : IServiceOrderRepository
    {
        private readonly ApplicationDbContext _context;

        public ServiceOrderRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CancelServiceOrder(Guid serviceOrderId)
        {
            ServiceOrder obj = await _context.ServiceOrders.Where(x => x.ServiceOrderId == serviceOrderId).FirstOrDefaultAsync();
            obj.CancelServiceOrder();
        }

        public async Task<List<ServiceOrderHasProducts>> GetServiceOrderById(Guid serviceOrderId)
        {
            List<ServiceOrderHasProducts> obj = await _context.ServiceOrderHasProducts
                .Where(x => x.ServiceOrder.ServiceOrderId == serviceOrderId)
                .Include(x => x.ServiceOrder)
                .Include(x => x.Product)
                .ToListAsync();
            return obj;
        }

        public async Task<List<ServiceOrderHasProducts>> GetServiceOrders()
        {
            List<ServiceOrderHasProducts> serviceProductList = await _context.ServiceOrderHasProducts.Include(x => x.ServiceOrder)
                .Include(x => x.Product).ToListAsync();
            
            return serviceProductList;
        }

        public async Task<ServiceOrder> Insert(ServiceOrder serviceOrder)
        {
            Client objClient = await _context.Clients.Where(x => x.ClientId == serviceOrder.Client.ClientId).FirstOrDefaultAsync();
            ServiceOrder objServiceOrder = new ServiceOrder(objClient);
            await _context.ServiceOrders.AddAsync(objServiceOrder);
            return objServiceOrder;
        }

        public async Task InsertDetail(ServiceOrderDetail serviceOrderDetail)
        {
            await _context.ServiceOrdersDetails.AddAsync(serviceOrderDetail);
        }

        public async Task InsertProducts(ServiceOrder serviceOrder, Product product)
        {
            Product objProduct = await _context.Products.Where(x => x.ProductId == product.ProductId).FirstOrDefaultAsync();
            ServiceOrderHasProducts objServiceProduct = new ServiceOrderHasProducts(serviceOrder, objProduct);
            await _context.ServiceOrderHasProducts.AddAsync(objServiceProduct);
        }
    }
}
