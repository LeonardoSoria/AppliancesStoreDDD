using System;
using System.Collections.Generic;
using System.Text;
using Tienda.SharedKernel.Core;

namespace Tienda.Soporte.Domain.Model.Soporte.Id
{
    public class AppointmentId : TypedIdValueBase
    {
        public AppointmentId(Guid value) : base(value)
        {

        }

        #region Conversion

        public static implicit operator Guid(AppointmentId value) => value.Value;

        public static implicit operator AppointmentId(Guid value) => new AppointmentId(value);

        #endregion
    }
}
