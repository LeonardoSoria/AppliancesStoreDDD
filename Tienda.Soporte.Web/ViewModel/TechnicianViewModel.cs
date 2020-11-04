using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tienda.Soporte.Web.ViewModel
{
    public class TechnicianViewModel
    {
        public Guid TechnicianId { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string CI { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}
