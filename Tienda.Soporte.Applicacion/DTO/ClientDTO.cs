using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tienda.Soporte.Infraestructura.DTO
{
    public class ClientDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }

        public ClientDTO()
        {
        }

        public ClientDTO(Guid id)
        {
            Id = id;
        }

        public ClientDTO(Guid id, string name, string lastname, string phone, string email, string address)
        {
            Id = id;
            Name = name;
            Lastname = lastname;
            Phone = phone;
            Email = email;
            Address = address;
        }
    }
}
