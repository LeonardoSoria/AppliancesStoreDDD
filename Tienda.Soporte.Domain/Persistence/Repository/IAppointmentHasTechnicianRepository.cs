using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tienda.Soporte.Domain.Model.Soporte;

namespace Tienda.Soporte.Domain.Persistence.Repository
{
    public interface IAppointmentHasTechnicianRepository
    {
        Task<List<AppointmentHasTechnician>> GetAppointmentHasTechnicians();

        Task<AppointmentHasTechnician> GetAppointmentHasTechnicianById(Guid appointmentHasTechnicianId);

        Task Insert(AppointmentHasTechnician appointmentHasTechnician);

        Task<AppointmentHasTechnician> Update(Guid appointmentHasTechnicianId, AppointmentHasTechnician appointmentHasTechnician);

        Task Delete(Guid appointmentHasTechnicianId);
    }
}
