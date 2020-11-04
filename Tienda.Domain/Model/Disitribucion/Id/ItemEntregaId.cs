using System;
using System.Collections.Generic;
using System.Text;
using Tienda.SharedKernel.Core;

namespace Tienda.Distribucion.Domain.Model.Disitribucion.Id
{
    public class ItemEntregaId : TypedIdValueBase
    {
        public ItemEntregaId(Guid value) : base(value)
        {
        }


        #region Conversion

        public static implicit operator Guid(ItemEntregaId value) => value.Value;

        public static implicit operator ItemEntregaId(Guid value) => new ItemEntregaId(value);

        #endregion
    }
}
