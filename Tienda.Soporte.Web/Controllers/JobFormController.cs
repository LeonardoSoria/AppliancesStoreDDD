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
    public class JobFormController : ControllerBase
    {
        private readonly IJobFormRepository _jobFormRepository;
        private readonly IUnitOfWork _unitOfWork;

        public JobFormController(IJobFormRepository jobFormRepository,
            IUnitOfWork unitOfWork)
        {
            _jobFormRepository = jobFormRepository;
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public async Task<IActionResult> InsertAppointment([FromBody] JobFormDTO jobForm)
        {
            try
            {
                JobForm objJobForm= new JobForm(jobForm.Detail, jobForm.Date, new Appointment(jobForm.Appointment.AppointmentId));
                await _jobFormRepository.Insert(objJobForm);
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
        public async Task<IActionResult> GetAllJobForms()
        {
            try
            {
                List<JobForm> jobFormList = await _jobFormRepository.GetJobForms();
                return Ok(new
                {
                    jobForms = jobFormList
                });
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> GetJobFormById(Guid id)
        {
            try
            {
                JobForm jobForm = await _jobFormRepository.GetJobFormById(id);
                return Ok(new
                {
                    JobForm = jobForm
                });
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}
