using System;
using System.Collections.Generic;
using System.Text;
using Tienda.SharedKernel.Core;

namespace Tienda.Soporte.Domain.Model.Soporte.Rules
{
    public class ChangeAppointmentStatusRule : IBusinessRule
    {
        private readonly AppointmentStatus oldStatus;
        private readonly AppointmentStatus newStatus;

        public ChangeAppointmentStatusRule(AppointmentStatus oldStatus, AppointmentStatus newStatus)
        {
            this.oldStatus = oldStatus;
            this.newStatus = newStatus;
        }

        public string Message => "No se puede cambiar del estado " + oldStatus.ToString() +
            " al estado " + newStatus.ToString();

        public bool IsBroken()
        {
            if (newStatus == AppointmentStatus.Inactive && oldStatus != AppointmentStatus.Inactive)
                return false;
            return true;
        }
    }
}
