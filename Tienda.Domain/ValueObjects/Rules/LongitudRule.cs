using System;
using System.Collections.Generic;
using System.Text;
using Tienda.SharedKernel.Core;

namespace Tienda.Distribucion.Domain.ValueObjects.Rules
{
    public class LongitudRule : IBusinessRule
    {
        private readonly decimal value;

        public LongitudRule(decimal value)
        {
            this.value = value;
        }

        public string Message => "Value must be between -180 and 180";

        public bool IsBroken()
        {
            return value < -180 || value > 180;
        }
    }
}
