using System;
using System.Collections.Generic;
using System.Text;
using Tienda.SharedKernel.Core;

namespace Tienda.Soporte.Domain.Model.Soporte.Id
{
    public class ServiceOrderId : TypedIdValueBase
    {
        public ServiceOrderId(Guid value) : base(value)
        {

        }

        #region Conversion

        public static implicit operator Guid(ServiceOrderId value) => value.Value;

        public static implicit operator ServiceOrderId(Guid value) => new ServiceOrderId(value);

        #endregion
    }
}
