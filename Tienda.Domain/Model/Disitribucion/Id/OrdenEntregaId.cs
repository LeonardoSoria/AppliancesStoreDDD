using System;
using System.Collections.Generic;
using System.Text;
using Tienda.SharedKernel.Core;

namespace Tienda.Distribucion.Domain.Model.Disitribucion.Id
{
    public class OrdenEntregaId : TypedIdValueBase
    {
        public OrdenEntregaId(Guid value) : base(value)
        {

        }

        #region Conversion

        public static implicit operator Guid(OrdenEntregaId value) => value.Value;

        public static implicit operator OrdenEntregaId(Guid value) => new OrdenEntregaId(value);

        #endregion
    }
}
