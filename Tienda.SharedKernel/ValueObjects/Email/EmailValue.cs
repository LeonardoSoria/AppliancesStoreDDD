using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using Tienda.SharedKernel.Core;
using Tienda.SharedKernel.ValueObjects.Email.Rules;

namespace Tienda.SharedKernel.ValueObjects.Email
{
    public class EmailValue : ValueObject, IComparable<EmailValue>
    {
        public string Value { get; private set; }

        public EmailValue(string value)
        {
            CheckRule(new NotNullRule<string>(value));
            CheckRule(new FormatEmailRule(value));
            Value = value;
        }

        #region Conversion

        public static implicit operator string(EmailValue value) => value.Value;

        public static implicit operator EmailValue(string value) => new EmailValue(value);

        #endregion

        public int CompareTo([AllowNull] EmailValue other)
        {
            return Value.CompareTo(other.Value);
        }
    }
}
