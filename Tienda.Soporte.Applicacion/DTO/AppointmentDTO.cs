using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tienda.Soporte.Domain.Model;

namespace Tienda.Soporte.Infraestructura.DTO
{
    public class AppointmentDTO
    {
        public Guid AppointmentId { get; set; }
        public AppointmentStatus Status { get; set; }
        public DateTime VisitDate { get; set; }
        public ServiceOrderDTO ServiceOrder { get; set; }
        public List<TechnicianDTO> Technicians { get; set; }
    }
}
