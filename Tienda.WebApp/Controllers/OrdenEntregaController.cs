using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Tienda.Distribucion.Applicacion.DTO;
using Tienda.Distribucion.Applicacion.Features.OrdenEntrega.GetAllOrdenEntrega;
using Tienda.Distribucion.Applicacion.Features.OrdenEntrega.InsertOrdenEntrega;
using Tienda.Distribucion.Applicacion.Features.OrdenEntrega.GetOrdenEntregaById;
using MediatR;

namespace Tienda.WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdenEntregaController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrdenEntregaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> InsertOrder([FromBody] InsertOrdenEntregaCommand ordenEntregaCommand)
        {
            try
            {
                await _mediator.Send(ordenEntregaCommand);

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

        [HttpGet]
        public async Task<IActionResult> GetOrders()
        {
            try
            {
                List<OrdenEntregaDTO> list = await _mediator.Send(new GetAllOrdenEntregaQuery());

                return Ok(new
                {
                    orders = list
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

        [HttpGet]
        [Route("{guid:Guid}")]
        public async Task<IActionResult> GetOrders(Guid guid)
        {
            try
            {
                OrdenEntregaDTO obj = await _mediator.Send(new GetOrdenEntregaByIdQuery(guid));

                return Ok(new
                {
                    order = obj
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

        [HttpGet]
        [Route("hello")]
        public string hello()
        {
            return "Hello";
        }


    }
}
