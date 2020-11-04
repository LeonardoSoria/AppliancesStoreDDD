using System;
using System.Collections.Generic;
using System.Text;
using Tienda.SharedKernel.Core;
using Tienda.SharedKernel.ValueObjects;
using Tienda.SharedKernel.ValueObjects.Email;
using Tienda.SharedKernel.ValueObjects.PhoneNumber;

namespace Tienda.Soporte.Domain.Model.Soporte
{
    public class Technician : Entity, IAggregateRoot
    {
        public Guid TechnicianId { get; private set; }
        public PersonNameValue Name { get; private set; }
        public PersonNameValue Lastname { get; private set; }
        public string CI { get; private set; }
        public PhoneNumberValue Phone { get; private set; }
        public EmailValue Email { get; private set; }

        public Technician(PersonNameValue name, PersonNameValue lastname, string ci, PhoneNumberValue phone, EmailValue email)
        {
            CheckRule(new NotNullRule<string>(ci));
            TechnicianId = Guid.NewGuid();
            Name = name;
            Lastname = lastname;
            CI = ci;
            Phone = phone;
            Email = email;
        }

        public Technician(Guid technicianId)
        {
            TechnicianId = technicianId;
        }

        protected Technician() { }

    }
}
