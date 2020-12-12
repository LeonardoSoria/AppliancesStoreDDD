using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tienda.Soporte.Applicacion.Features.ServiceOrder.Command;
using Tienda.Soporte.Applicacion.Features.ServiceOrder.Query;
using Tienda.Soporte.Domain.Model.Soporte;
using Tienda.Soporte.Domain.Persistence;
using Tienda.Soporte.Domain.Persistence.Repository;
using Tienda.Soporte.Infraestructura.DTO;

namespace Tienda.Soporte.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceOrderController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ServiceOrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> InsertServiceOrder([FromBody] ServiceOrderDetailDTO serviceOrderDetail)
        {
            try
            {
                await _mediator.Send(new InsertServiceOrderCommand(serviceOrderDetail));
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
        public async Task<IActionResult>  CancelServiceOrder([FromBody] CancellationDTO cancellation)
        {
            try
            {
                //await _serviceOrderRepository.CancelServiceOrder(cancellation.Id);
                //await _unitOfWork.Commit();
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
                List<ServiceOrderHasProductsDTO> serviceOrder = await _mediator.Send(new GetAllServiceOrdersQuery());
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

        //[HttpGet("{id:Guid}")]
        //public async Task<IActionResult> GetServiceOrdersById(Guid id)
        //{
        //    try
        //    {
        //        List<ServiceOrderHasProducts> serviceOrder = await _serviceOrderRepository.GetServiceOrderById(id);
        //        return Ok(new
        //        {
        //            ServiceOrders = serviceOrder
        //        });
        //    }
        //    catch (Exception e)
        //    {
        //        return BadRequest(e);
        //    }
        //}
    }
}
