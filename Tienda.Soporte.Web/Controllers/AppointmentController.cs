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
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AppointmentController(IAppointmentRepository appointmentRepository,
            IUnitOfWork unitOfWork)
        {
            _appointmentRepository = appointmentRepository;
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public async Task<IActionResult> InsertAppointment([FromBody] AppointmentDTO appointment)
        {
            try
            {
                Appointment objAppointment= new Appointment(appointment.VisitDate, new ServiceOrder(appointment.ServiceOrder.Id));
                Appointment appo = await _appointmentRepository.Insert(objAppointment);
                await _unitOfWork.Commit();
                foreach (TechnicianDTO technician in appointment.Technicians)
                {
                    await _appointmentRepository.InsertTechniciansInAppointment(appo, new Technician(technician.TechnicianId));
                    await _unitOfWork.Commit();
                }
                return Ok(new { 
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

        [HttpPost]
        [Route("cancelAppointment")]
        public async Task<IActionResult> CancelServiceOrder([FromBody] CancellationDTO cancellation)
        {
            try
            {
                await _appointmentRepository.CancelAppointment(cancellation.Id);
                await _unitOfWork.Commit();
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest(e);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAppointments()
        {
            try
            {
                List<AppointmentHasTechnician> appointmentList = await _appointmentRepository.GetAppointments();
                return Ok(new
                {
                    Appoinments = appointmentList
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
                List<AppointmentHasTechnician> appointments = await _appointmentRepository.GetAppointmentById(id);
                return Ok(new
                {
                    Appointments = appointments
                });
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}
