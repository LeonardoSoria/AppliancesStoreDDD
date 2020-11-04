using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tienda.Soporte.Web.ViewModel
{
    public class ProductViewModel
    {
        public Guid Id { get; set; }
        public string ProductBrand { get; set; }
        public string ProductName { get; set; }
        public double ProductPrice { get; set; } 
    }
}
