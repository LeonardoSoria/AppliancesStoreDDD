using System;
using System.Collections.Generic;
using System.Text;
using Tienda.SharedKernel.Core;

namespace Tienda.Distribucion.Domain.Model.Disitribucion.Id
{
    public class ViajeEntregaId : TypedIdValueBase
    {
        public ViajeEntregaId(Guid value) : base(value)
        {

        }

        #region Conversion

        public static implicit operator Guid(ViajeEntregaId value) => value.Value;

        public static implicit operator ViajeEntregaId(Guid value) => new ViajeEntregaId(value);

        #endregion
    }
}
