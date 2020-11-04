using System;
using System.Collections.Generic;
using System.Text;
using Tienda.SharedKernel.Core;

namespace Tienda.Soporte.Domain.Model.Soporte
{
    public class ServiceOrderDetail : Entity, IAggregateRoot
    {
        public Guid ServiceOrderDetailId { get; private set; }
        public ServiceTypeEnum ServiceType { get; private set; }
        public Double Price { get; private set; }
        public ServiceOrder ServiceOrder { get; private set; }
        public string Description { get; private set; }
        public string AlternativeAddress { get; private set; }

        public ServiceOrderDetail(ServiceTypeEnum serviceType, Double price, ServiceOrder serviceOrder, 
            string description, string alternativeAddress)
        {
            CheckRule(new NotNullRule<string>(description));
            ServiceOrderDetailId = Guid.NewGuid();
            ServiceType = serviceType;
            Price = price;
            ServiceOrder = serviceOrder;
            Description = description;
            AlternativeAddress = alternativeAddress;
        }

        protected ServiceOrderDetail() { }
    }
}
