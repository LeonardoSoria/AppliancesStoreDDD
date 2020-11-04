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
    public class JobFormRepository : IJobFormRepository
    {
        private readonly ApplicationDbContext _context;

        public JobFormRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task Delete(Guid jobFormId)
        {
            throw new NotImplementedException();
        }

        public async Task<JobForm> GetJobFormById(Guid jobFormId)
        {
            JobForm obj = await _context.JobForms.Where(x => x.JobFormId == jobFormId)
                .Include(x => x.Appointment)
                .FirstOrDefaultAsync();
            return obj;
        }

        public async Task<List<JobForm>> GetJobForms()
        {
            List<JobForm> jobFormList = await _context.JobForms
                .Include(x => x.Appointment)
                .ToListAsync();
            return jobFormList;
        }

        public async Task Insert(JobForm jobForm)
        {
            Appointment objAppointment = await _context.Appointments.Where(x => x.AppointmentId == jobForm.Appointment.AppointmentId)
                .FirstOrDefaultAsync();

            JobForm objJobForm = new JobForm(jobForm.Detail, jobForm.Date, objAppointment);
            await _context.JobForms.AddAsync(objJobForm);
        }

        public Task<JobForm> Update(Guid JobFormId, JobForm jobForm)
        {
            throw new NotImplementedException();
        }
    }
}
