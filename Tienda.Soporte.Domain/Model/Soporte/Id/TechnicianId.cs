using System;
using System.Collections.Generic;
using System.Text;
using Tienda.SharedKernel.Core;

namespace Tienda.Soporte.Domain.Model.Soporte.Id
{
    public class TechnicianId : TypedIdValueBase
    {
        public TechnicianId(Guid value) : base(value)
        {

        }

        #region Conversion

        public static implicit operator Guid(TechnicianId value) => value.Value;

        public static implicit operator TechnicianId(Guid value) => new TechnicianId(value);

        #endregion
    }
}
