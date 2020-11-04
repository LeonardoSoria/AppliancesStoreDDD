using System;
using System.Collections.Generic;
using System.Text;
using Tienda.SharedKernel.Core;
using Tienda.Soporte.Domain.Model.Soporte;
using Tienda.Soporte.Domain.Model.Soporte.Rules;

namespace Tienda.Soporte.Domain.Model.Soporte
{
    public class ServiceOrder: Entity, IAggregateRoot
    {
        public Guid ServiceOrderId { get; private set; }
        public DateTime CreationDate { get; private set; }
        public Client Client { get; private set; } 
        public ServiceOrderStatus Status { get; private set; }
        public ServiceOrder(Client client)
        {
            ServiceOrderId = Guid.NewGuid();
            CreationDate = DateTime.Now;
            Client = client;
            Status = ServiceOrderStatus.Active;
        }

        public ServiceOrder(Guid serviceOrderId)
        {
            ServiceOrderId = serviceOrderId;
        }

        protected ServiceOrder() { }

        public void CancelServiceOrder()
        {
            CheckRule(new ChangeOrderServiceStatusRule(Status, ServiceOrderStatus.Inactive));
            Status = ServiceOrderStatus.Inactive;
        }
    }
}
