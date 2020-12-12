using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tienda.Soporte.Infraestructura.DTO
{
    public class ProductDTO
    {
        public Guid Id { get; set; }
        public string ProductBrand { get; set; }
        public string ProductName { get; set; }
        public double ProductPrice { get; set; }

        public ProductDTO()
        {
        }

        public ProductDTO(Guid id)
        {
            Id = id;
        }

        public ProductDTO(Guid id, string productBrand, string productName, double productPrice)
        {
            Id = id;
            ProductBrand = productBrand;
            ProductName = productName;
            ProductPrice = productPrice;
        }
    }
}
