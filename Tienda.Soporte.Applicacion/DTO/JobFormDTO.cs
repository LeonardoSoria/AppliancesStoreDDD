using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tienda.Soporte.Infraestructura.DTO
{
    public class JobFormDTO
    {
        public Guid JobFormId { get; set; }
        public string Detail { get; set; }
        public DateTime Date { get; set; }
        public AppointmentDTO Appointment { get; set; }
    }
}
