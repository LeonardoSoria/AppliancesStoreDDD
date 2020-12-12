using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tienda.Soporte.Domain.Model.Soporte;
using Tienda.Soporte.Domain.Persistence;
using Tienda.Soporte.Domain.Persistence.Repository;
using Tienda.Soporte.Infraestructura.DTO;

namespace Tienda.Soporte.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TechnicianController : ControllerBase
    {
        private readonly ITechnicianRepository _technicianRepository;
        private readonly IUnitOfWork _unitOfWork;

        public TechnicianController(ITechnicianRepository technicianRepository,
            IUnitOfWork unitOfWork)
        {
            _technicianRepository = technicianRepository;
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public async Task<IActionResult> InsertTechnician([FromBody] TechnicianDTO technician)
        {
            try
            {
                Technician objTechnician = new Technician(technician.Name, technician.Lastname, technician.CI, technician.Phone,
                    technician.Email);
                await _technicianRepository.Insert(objTechnician);
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
                    Error = e
                });
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTechnicians()
        {
            try
            {
                List<Technician> technicianList = await _technicianRepository.GetTechnicians();
                return Ok(new
                {
                    technicians = technicianList
                });
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> GetTechnicianById(Guid id)
        {
            try
            {
                Technician technician = await _technicianRepository.GetTechnicianById(id);
                return Ok(new
                {
                    Technician = technician
                });
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}
