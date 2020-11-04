using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Tienda.SharedKernel.Core;

namespace Tienda.SharedKernel.ValueObjects.Email.Rules
{
    class FormatEmailRule : IBusinessRule
    {
        private readonly string _value;
        public FormatEmailRule(string value)
        {
            _value = value;
        }
        public string Message => "El email no cumple con el formato correcto";

        public bool IsBroken()
        {
            return !Regex.IsMatch(_value, "^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$");
        }
    }
}
