using System;
using System.Collections.Generic;
using System.Text;
using Tienda.SharedKernel.Core;

namespace Tienda.Soporte.Domain.Model.Soporte.Id
{
    public class ClientId : TypedIdValueBase
    {
        public ClientId(Guid value) : base(value)
        {

        }

        #region Conversion

        public static implicit operator Guid(ClientId value) => value.Value;

        public static implicit operator ClientId(Guid value) => new ClientId(value);

        #endregion
    }
}
