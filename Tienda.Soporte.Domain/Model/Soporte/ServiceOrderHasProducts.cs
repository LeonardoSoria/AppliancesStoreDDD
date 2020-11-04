using System;
using System.Collections.Generic;
using System.Text;
using Tienda.SharedKernel.Core;

namespace Tienda.Soporte.Domain.Model.Soporte
{
    public class ServiceOrderHasProducts : Entity, IAggregateRoot
    {
        public Guid ServiceOrdersHasProductsId { get; private set; }
        public ServiceOrder ServiceOrder { get; private set; }
        public Product Product { get; private set; }

        public ServiceOrderHasProducts(ServiceOrder serviceOrder, Product product)
        {
            ServiceOrder = serviceOrder;
            Product = product;
        }

        protected ServiceOrderHasProducts() { }
    }
}
