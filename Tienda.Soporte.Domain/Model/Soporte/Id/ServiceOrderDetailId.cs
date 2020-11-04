using System;
using System.Collections.Generic;
using System.Text;
using Tienda.SharedKernel.Core;

namespace Tienda.Soporte.Domain.Model.Soporte.Id
{
    class ServiceOrderDetailId : TypedIdValueBase
    {
        public ServiceOrderDetailId(Guid value) : base(value)
        {

        }

        #region Conversion

        public static implicit operator Guid(ServiceOrderDetailId value) => value.Value;

        public static implicit operator ServiceOrderDetailId(Guid value) => new ServiceOrderDetailId(value);

        #endregion
    }
}
