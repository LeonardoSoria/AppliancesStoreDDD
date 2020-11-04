using System;
using System.Collections.Generic;
using System.Text;
using Tienda.SharedKernel.Core;
using Tienda.Soporte.Domain.Model.Soporte.Rules;

namespace Tienda.Soporte.Domain.Model.Soporte
{
    public class Appointment : Entity, IAggregateRoot
    {
        public Guid AppointmentId { get; private set; }
        public AppointmentStatus Status { get; private set; }
        public DateTime VisitDate { get; private set; }
        public ServiceOrder ServiceOrder { get; private set; }

        public Appointment(DateTime visitDate, ServiceOrder serviceOrder)
        {
            AppointmentId = Guid.NewGuid();
            Status = AppointmentStatus.Active;
            VisitDate = visitDate;
            ServiceOrder = serviceOrder;
        }

        public Appointment(Guid appointmentId)
        {
            AppointmentId = appointmentId;
        }

        protected Appointment() { }

        public void CancelAppointment()
        {
            CheckRule(new ChangeAppointmentStatusRule(Status, AppointmentStatus.Inactive));
            Status = AppointmentStatus.Inactive;
        }
    }
}
