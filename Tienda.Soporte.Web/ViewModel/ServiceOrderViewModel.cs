using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tienda.Soporte.Domain.Model.Soporte;

namespace Tienda.Soporte.Web.ViewModel
{
    public class ServiceOrderViewModel
    {
        public Guid Id { get; set; }
        public DateTime CreationDate { get; set; }
        public ClientViewModel Client { get; set; }
        public ServiceOrderStatus Status { get; set; }
    }
}
