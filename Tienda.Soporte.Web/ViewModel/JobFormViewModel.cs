using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tienda.Soporte.Web.ViewModel
{
    public class JobFormViewModel
    {
        public Guid JobFormId { get; set; }
        public string Detail { get; set; }
        public DateTime Date { get; set; }
        public AppointmentViewModel Appointment { get; set; }
    }
}
