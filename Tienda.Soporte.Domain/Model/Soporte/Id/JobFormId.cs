using System;
using System.Collections.Generic;
using System.Text;
using Tienda.SharedKernel.Core;

namespace Tienda.Soporte.Domain.Model.Soporte.Id
{
    public class JobFormId : TypedIdValueBase
    {
        public JobFormId(Guid value) : base(value)
        {

        }

        #region Conversion

        public static implicit operator Guid(JobFormId value) => value.Value;

        public static implicit operator JobFormId(Guid value) => new JobFormId(value);

        #endregion
    }
}
