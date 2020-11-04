using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tienda.Soporte.Domain.Model;

namespace Tienda.Soporte.Web.ViewModel
{
    public class AppointmentViewModel
    {
        public Guid AppointmentId { get; set; }
        public AppointmentStatus Status { get; set; }
        public DateTime VisitDate { get; set; }
        public ServiceOrderViewModel ServiceOrder { get; set; }
        public List<TechnicianViewModel> Technicians { get; set; }
    }
}
