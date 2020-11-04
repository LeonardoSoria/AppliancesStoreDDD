using System;
using System.Collections.Generic;
using System.Text;
using Tienda.SharedKernel.Core;

namespace Tienda.Distribucion.Domain.Model.Disitribucion.Id
{
    public class SeguimientoViajeItemId : TypedIdValueBase
    {
        public SeguimientoViajeItemId(Guid value) : base(value)
        {

        }

        #region Conversion

        public static implicit operator Guid(SeguimientoViajeItemId value) => value.Value;

        public static implicit operator SeguimientoViajeItemId(Guid value) => new SeguimientoViajeItemId(value);

        #endregion

    }
}
