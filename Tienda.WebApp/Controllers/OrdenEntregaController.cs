using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Tienda.Distribucion.Domain.Model.Disitribucion;
using Tienda.Distribucion.Domain.Persistence;
using Tienda.Distribucion.Domain.Persistence.Reporsitory;
using Tienda.WebApp.ViewModel;

namespace Tienda.WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdenEntregaController : ControllerBase
    {
        private readonly IOrdenEntregaRepository _ordenEntregaRepository;
        private readonly IUnitOfWork _unitOfWork;

        public OrdenEntregaController(IOrdenEntregaRepository ordenEntregaRepository,
            IUnitOfWork unitOfWork)
        {
            _ordenEntregaRepository = ordenEntregaRepository;
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public async Task<IActionResult> InsertOrder([FromBody] OrdenEntregaViewModel ordenEntrega)
        {
            try
            {
                List<ItemEntrega> items = new List<ItemEntrega>();
                foreach (var item in ordenEntrega.Items)
                {
                    items.Add(new ItemEntrega(item.Codigo, item.Descripcion));
                }

                OrdenEntrega obj = new OrdenEntrega(ordenEntrega.NombreCliente,
                    ordenEntrega.Telefono,
                    ordenEntrega.LatitudDestino,
                    ordenEntrega.LongitudDestino,
                    items
                    );

                await _ordenEntregaRepository.Insert(obj);

                await _unitOfWork.Commit();

                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return BadRequest();
        }

        [HttpGet]        
        [Route("hello")]
        public string hello()
        {
            return "Hello";
        }

    }
}
