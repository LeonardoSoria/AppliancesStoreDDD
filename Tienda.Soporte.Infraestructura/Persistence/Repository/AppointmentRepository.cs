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
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly ApplicationDbContext _context;

        public AppointmentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task Delete(Guid appointmentId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<AppointmentHasTechnician>> GetAppointmentById(Guid appointmentId)
        {
            List<AppointmentHasTechnician> appointmentList = await _context.AppointmentHasTechnicians
                .Where(x => x.Appointment.AppointmentId == appointmentId)
                .Include(x => x.Appointment)
                .Include(x => x.Technician)
                .ToListAsync();
            return appointmentList;
        }

        public async Task<List<AppointmentHasTechnician>> GetAppointments()
        {
            List<AppointmentHasTechnician> appointmentList = await _context.AppointmentHasTechnicians
                .Include(x => x.Appointment)
                .Include(x => x.Technician)
                .ToListAsync();
            return appointmentList;
        }

        public async Task InsertTechniciansInAppointment(Appointment appointment, Technician technician)
        {
            Technician objTechnician = await _context.Technicians.Where(x => x.TechnicianId == technician.TechnicianId)
                .FirstOrDefaultAsync();
            Appointment objAppointment = await _context.Appointments.Where(x => x.AppointmentId == appointment.AppointmentId)
                .FirstOrDefaultAsync();
            // Appointment appointment = await _context.Appointments.LastOrDefaultAsync();
            AppointmentHasTechnician appointmentHasTechnician = new AppointmentHasTechnician(objAppointment, objTechnician);
            await _context.AppointmentHasTechnicians.AddAsync(appointmentHasTechnician);
        }

        public async Task<Appointment> Insert(Appointment appointment)
        {
            ServiceOrder objServiceOrder = await _context.ServiceOrders
                .Where(x => x.ServiceOrderId == appointment.ServiceOrder.ServiceOrderId).FirstOrDefaultAsync();
            Appointment objAppointment = new Appointment(appointment.VisitDate, objServiceOrder);
            await _context.Appointments.AddAsync(objAppointment);
            return objAppointment;
        }

        public Task<Appointment> Update(Guid appointmentId, Appointment appointment)
        {
            throw new NotImplementedException();
        }

        public async Task CancelAppointment(Guid appointmentId)
        {
            Appointment obj = await _context.Appointments.Where(x => x.AppointmentId == appointmentId).FirstOrDefaultAsync();
            obj.CancelAppointment();
        }
    }
}
