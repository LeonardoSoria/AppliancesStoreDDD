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
    public class ServiceOrderDetailRepository : IServiceOrderDetailRepository 
    {
        private readonly ApplicationDbContext _context;
        
        public ServiceOrderDetailRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Delete(Guid serviceOrderDetailId)
        {
            ServiceOrderDetail obj = await _context.ServiceOrdersDetails.Where(x => x.ServiceOrderDetailId == serviceOrderDetailId)
                .FirstOrDefaultAsync();
            _context.ServiceOrdersDetails.Remove(obj);
        }

        public async Task<List<ServiceOrderDetail>> GetServiceOrderDetailById(Guid serviceOrderId)
        {
            List<ServiceOrderDetail> objServiceOrderDetail = await _context.ServiceOrdersDetails
                .Where(x => x.ServiceOrder.ServiceOrderId == serviceOrderId)
                .Include(x => x.ServiceOrder)
                .Include(x => x.ServiceOrder.Client)
                .ToListAsync();
            return objServiceOrderDetail;
        }

        public async Task<List<ServiceOrderDetail>> GetServiceOrderDetails()
        {
            List<ServiceOrderDetail> serviceOrderDetailList = await _context.ServiceOrdersDetails
                .Include(x => x.ServiceOrder)
                .Include(x => x.ServiceOrder.Client)
                .ToListAsync();
            return serviceOrderDetailList;
        }

        public async Task Insert(ServiceOrderDetail serviceOrderDetail)
        {
            ServiceOrder objServiceOrder = await _context.ServiceOrders
                .Where(x => x.ServiceOrderId == serviceOrderDetail.ServiceOrder.ServiceOrderId).FirstOrDefaultAsync();
            ServiceOrderDetail objServiceOrderDetail = new ServiceOrderDetail(serviceOrderDetail.ServiceType, serviceOrderDetail.Price,
                objServiceOrder, serviceOrderDetail.Description, serviceOrderDetail.AlternativeAddress);
            await _context.ServiceOrdersDetails.AddAsync(objServiceOrderDetail);
        }

        public async Task<ServiceOrderDetail> Update(Guid serviceOrderDetailId, ServiceOrderDetail serviceOrderDetail)
        {
            ServiceOrderDetail obj = await _context.ServiceOrdersDetails
                .Where(x => x.ServiceOrderDetailId == serviceOrderDetail.ServiceOrderDetailId).FirstOrDefaultAsync();
            _context.Entry(obj).CurrentValues.SetValues(serviceOrderDetail);
            return serviceOrderDetail;
        }
    }
}
