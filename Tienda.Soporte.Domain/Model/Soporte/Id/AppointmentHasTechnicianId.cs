using System;
using System.Collections.Generic;
using System.Text;
using Tienda.SharedKernel.Core;

namespace Tienda.Soporte.Domain.Model.Soporte.Id
{
    public class AppointmentHasTechnicianId : TypedIdValueBase
    {
        public AppointmentHasTechnicianId(Guid value) : base(value)
        {

        }

        #region Conversion

        public static implicit operator Guid(AppointmentHasTechnicianId value) => value.Value;

        public static implicit operator AppointmentHasTechnicianId(Guid value) => new AppointmentHasTechnicianId(value);

        #endregion
    }
}
