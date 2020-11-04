using System;
using System.Collections.Generic;
using System.Text;
using Tienda.SharedKernel.Core;
using Tienda.SharedKernel.ValueObjects;
using Tienda.SharedKernel.ValueObjects.PhoneNumber;
using Tienda.SharedKernel.ValueObjects.Email;

namespace Tienda.Soporte.Domain.Model.Soporte
{
    public class Client : Entity, IAggregateRoot
    {
        public Guid ClientId { get; private set; }
        public PersonNameValue Name { get; private set; }
        public PersonNameValue Lastname { get; private set; }
        public PhoneNumberValue Phone { get; private set; }
        public EmailValue Email { get; private set; }
        public string Address { get; private set; }

        public Client(PersonNameValue name, PersonNameValue lastname, PhoneNumberValue phone, EmailValue email, string address)
        {
            CheckRule(new NotNullRule<string>(address));
            ClientId = Guid.NewGuid();
            Name = name;
            Lastname = lastname;
            Phone = phone;
            Email = email;
            Address = address;
        }

        public Client(Guid clientId)
        {
            ClientId = clientId;
        }

        protected Client() { }

    }
}
