using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tienda.Soporte.Domain.Model.Soporte;
using Tienda.Soporte.Domain.Persistence;
using Tienda.Soporte.Domain.Persistence.Repository;
using Tienda.Soporte.Web.ViewModel;

namespace Tienda.Soporte.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceOrderController : ControllerBase
    {
        private readonly IServiceOrderRepository _serviceOrderRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ServiceOrderController(IServiceOrderRepository serviceOrderRepository,
            IUnitOfWork unitOfWork)
        {
            _serviceOrderRepository = serviceOrderRepository;
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public async Task<IActionResult> InsertServiceOrder([FromBody] ServiceOrderDetailViewModel serviceOrderDetail)
        {
            try
            {
                ServiceOrder objServiceOrder = await _serviceOrderRepository.Insert(
                    new ServiceOrder(new Client(serviceOrderDetail.ServiceOrder.Client.Id)));

                await _serviceOrderRepository.InsertDetail(new ServiceOrderDetail((ServiceTypeEnum) serviceOrderDetail.ServiceType, 
                    serviceOrderDetail.Price, objServiceOrder, serviceOrderDetail.Description, serviceOrderDetail.AlternativeAddress));

                foreach (ProductViewModel product in serviceOrderDetail.Products)
                {
                    await _serviceOrderRepository.InsertProducts(objServiceOrder, new Product(product.Id));
                }

                await _unitOfWork.Commit();
                return Ok(new
                {
                    Ok = true,
                    Message = "Registro insertado exitosamente"
                });
            }
            catch (Exception e)
            {
                return BadRequest(new
                {
                    Ok = false,
                    Error = e.Message
                });
            }
        }

        
        [HttpPost]
        [Route("cancelServiceOrder")]
        public async Task<IActionResult>  CancelServiceOrder([FromBody] CancellationViewModel cancellation)
        {
            try
            {
                await _serviceOrderRepository.CancelServiceOrder(cancellation.Id);
                await _unitOfWork.Commit();
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest();
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllServiceOrders()
        {
            try
            {
                List<ServiceOrderHasProducts> serviceOrder = await _serviceOrderRepository.GetServiceOrders();
                return Ok(new
                {
                    serviceOrders = serviceOrder
                });
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> GetServiceOrdersById(Guid id)
        {
            try
            {
                List<ServiceOrderHasProducts> serviceOrder = await _serviceOrderRepository.GetServiceOrderById(id);
                return Ok(new
                {
                    ServiceOrders = serviceOrder
                });
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}
