using System;
using System.Collections.Generic;
using System.Text;
using Tienda.SharedKernel.Core;

namespace Tienda.Distribucion.Domain.ValueObjects.Rules
{
    public class LatitudRule : IBusinessRule
    {
        private readonly decimal value;

        public LatitudRule(decimal value)
        {
            this.value = value;
        }

        public string Message => "Value must be between -90 and 90";

        public bool IsBroken()
        {
            return value < -90 || value > 90;
        }
    }
}
