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
using Tienda.Distribucion.Applicacion.Features.OrdenEntrega.ConsolidadOrdenEntrega;
using Tienda.Distribucion.Applicacion.Features.OrdenEntrega.FinalizarOrdenEntrega;
using Tienda.Distribucion.Applicacion.Features.OrdenEntrega.CancelarOrdenEntrega;
using Tienda.Distribucion.Applicacion.Features.OrdenEntrega.IniciarViaje;
using Tienda.Distribucion.Applicacion.Features.OrdenEntrega.FinalizarViajeEntrega;
using Tienda.Distribucion.Applicacion.Features.OrdenEntrega.InsertarSeguimientoViajeItem;

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

        [HttpPost]
        [Route("consolidarOrdenEntrega")]
        public async Task<IActionResult> ConsolidarOrdenEntrega([FromBody] ViajeEntregaDTO viajeEntrega)
        {
            try
            {
                await _mediator.Send(new ConsolidarOrdenEntregaCommand(viajeEntrega));

                return Ok(new
                {
                    Ok = true,
                    Message = "La orden de entrega se ha consolidado exitosamente"
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
        [Route("finalizarOrdenEntrega")]
        public async Task<IActionResult> FinalizarOrdenEntrega([FromBody] CambiarEstadoOrdenEntregaDTO cambiarEstado)
        {
            try
            {
                await _mediator.Send(new FinalizarOrdenEntregaCommand(cambiarEstado));

                return Ok(new
                {
                    Ok = true,
                    Message = "La orden de entrega se ha finalizado exitosamente"
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
        [Route("anularOrdenEntrega")]
        public async Task<IActionResult> AnularOrdenEntrega([FromBody] CambiarEstadoOrdenEntregaDTO cambiarEstado)
        {
            try
            {
                await _mediator.Send(new AnularOrdenEntregaCommand(cambiarEstado));

                return Ok(new
                {
                    Ok = true,
                    Message = "La orden de entrega se ha anulado exitosamente"
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
        [Route("iniciarViaje")]
        public async Task<IActionResult> IniciarViaje([FromBody] CambiarFechaViajeEntregaDTO cambiarFecha)
        {
            try
            {
                await _mediator.Send(new IniciarViajeEntregaCommand(cambiarFecha));

                return Ok(new
                {
                    Ok = true,
                    Message = "El viaje se ha iniciado exitosamente"
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
        [Route("finalizarViaje")]
        public async Task<IActionResult> FinalizarViaje([FromBody] CambiarFechaViajeEntregaDTO cambiarFecha)
        {
            try
            {
                await _mediator.Send(new FinalizarViajeEntregaCommand(cambiarFecha));

                return Ok(new
                {
                    Ok = true,
                    Message = "El viaje se ha finalizado exitosamente"
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
        [Route("insertarSeguimiento")]
        public async Task<IActionResult> InsertarSeguimiento([FromBody] SeguimientoViajeItemDTO seguimiento)
        {
            try
            {
                await _mediator.Send(new InsertarSeguimientoVIajeItemCommand(seguimiento));

                return Ok(new
                {
                    Ok = true,
                    Message = "El seguimiento se ha registrado exitosamente"
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


    }
}
