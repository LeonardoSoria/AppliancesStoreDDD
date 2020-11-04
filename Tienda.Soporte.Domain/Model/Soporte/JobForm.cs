using System;
using System.Collections.Generic;
using System.Text;
using Tienda.SharedKernel.Core;

namespace Tienda.Soporte.Domain.Model.Soporte
{
    public class JobForm : Entity, IAggregateRoot
    {
        public Guid JobFormId { get; private set; }
        public string Detail { get; private set; }
        public DateTime Date { get; private set; }
        public Appointment Appointment { get; private set; }

        public JobForm(string detail, DateTime date, Appointment appointment)
        {
            CheckRule(new NotNullRule<string>(detail));
            JobFormId = Guid.NewGuid();
            Detail = detail;
            Date = date;
            Appointment = appointment;
        }

        protected JobForm() { }
    }
}
