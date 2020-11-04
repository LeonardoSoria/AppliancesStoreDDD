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
    public class ClientController : ControllerBase
    {
        private readonly IClientRepository _clientRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ClientController(IClientRepository clientRepository,
            IUnitOfWork unitOfWork)
        {
            _clientRepository = clientRepository;
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public async Task<IActionResult> InsertClient([FromBody] ClientViewModel client)
        {
            try
            {
                Client objClient = new Client(client.Name, client.Lastname, client.Phone, client.Email, client.Address);
                await _clientRepository.Insert(objClient);
                await _unitOfWork.Commit();
                return Ok(new
                {
                    Ok = true,
                    Message = "Registro insertado exitosamente"
                });
            } catch (Exception e)
            {
                return BadRequest(new { 
                    Ok = false,
                    Error = e
                });
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllClients()
        {
            try
            {
                List<Client> clientList = await _clientRepository.GetClients();
                return Ok(new { 
                    clients = clientList
                });
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> GetClientById(Guid id)
        {
            try
            {
                Client client = await _clientRepository.GetClientById(id);
                return Ok(new
                {
                    Client = client
                });
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}
