using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tienda.Soporte.Domain.Model.Soporte;

namespace Tienda.Soporte.Domain.Persistence.Repository
{
    public interface IAppointmentRepository
    {
        Task<List<AppointmentHasTechnician>> GetAppointments();

        Task<List<AppointmentHasTechnician>> GetAppointmentById(Guid appointmentId);

        Task InsertTechniciansInAppointment(Appointment appointment, Technician technician);

        Task<Appointment> Insert(Appointment appointment);

        Task<Appointment> Update(Guid appointmentId, Appointment appointment);

        Task Delete(Guid appointmentId);

        Task CancelAppointment(Guid serviceOrderId);
    }
}
