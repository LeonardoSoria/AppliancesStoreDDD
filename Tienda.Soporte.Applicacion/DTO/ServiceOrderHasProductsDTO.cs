using System;
using System.Collections.Generic;
using System.Text;

namespace Tienda.Soporte.Infraestructura.DTO
{
    public class ServiceOrderHasProductsDTO
    {
        public Guid ServiceOrdersHasProductsId { get; set; }
        public ServiceOrderDTO ServiceOrder { get; set; }
        public ProductDTO Product { get; set; }

        public ServiceOrderHasProductsDTO()
        {
        }

        public ServiceOrderHasProductsDTO(Guid serviceOrdersHasProductsId, ServiceOrderDTO serviceOrder, ProductDTO product)
        {
            ServiceOrdersHasProductsId = serviceOrdersHasProductsId;
            ServiceOrder = serviceOrder;
            Product = product;
        }
    }
}
