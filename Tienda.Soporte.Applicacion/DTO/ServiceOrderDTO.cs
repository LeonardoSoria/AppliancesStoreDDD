using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tienda.Soporte.Domain.Model.Soporte;

namespace Tienda.Soporte.Infraestructura.DTO
{
    public class ServiceOrderDTO
    {
        public Guid Id { get; set; }
        public DateTime CreationDate { get; set; }
        public ClientDTO Client { get; set; }
        public ServiceOrderStatus Status { get; set; }

        public ServiceOrderDTO()
        {
        }

        public ServiceOrderDTO(Guid id, DateTime creationDate, ClientDTO client, ServiceOrderStatus status)
        {
            Id = id;
            CreationDate = creationDate;
            Client = client;
            Status = status;
        }
    }
}
