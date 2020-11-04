using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tienda.Soporte.Domain.Model.Soporte;

namespace Tienda.Soporte.Web.ViewModel
{
    public class ServiceOrderDetailViewModel
    {
        public Guid ServiceOrderDetailId { get; set; }
        public int ServiceType { get; set; }
        public Double Price { get; set; }
        public ServiceOrderViewModel ServiceOrder { get; set; }
        public string Description { get; set; }
        public string AlternativeAddress { get; set; }
        public List<ProductViewModel> Products { get; set; }
    }
}
