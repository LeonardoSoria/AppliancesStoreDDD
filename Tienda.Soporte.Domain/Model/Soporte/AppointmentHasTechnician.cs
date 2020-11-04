using System;
using System.Collections.Generic;
using System.Text;

namespace Tienda.Soporte.Domain.Model.Soporte
{
    public class AppointmentHasTechnician
    {
        public Guid AppoinmtentHasTechnicianId { get; private set; }
        public Appointment Appointment { get; private set; }
        public Technician Technician { get; private set; }

        public AppointmentHasTechnician(Appointment appointment, Technician technician)
        {
            AppoinmtentHasTechnicianId = Guid.NewGuid();
            Appointment = appointment;
            Technician = technician;
        }

        protected AppointmentHasTechnician() { }
    }
}
