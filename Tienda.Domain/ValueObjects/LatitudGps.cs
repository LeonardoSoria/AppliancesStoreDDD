using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using Tienda.Distribucion.Domain.ValueObjects.Rules;
using Tienda.SharedKernel.Core;

namespace Tienda.Distribucion.Domain.ValueObjects
{
    public class LatitudGps : ValueObject, IComparable<LatitudGps>
    {
        public decimal Value { get; private set; }

        public LatitudGps(decimal value)
        {
            CheckRule(new LatitudRule(value));

            Value = value;
        }

        public int CompareTo([AllowNull] LatitudGps other)
        {
            return Value.CompareTo(other);
        }

        #region Conversion

        public static implicit operator decimal(LatitudGps value) => value.Value;

        public static implicit operator LatitudGps(decimal value) => new LatitudGps(value);

        #endregion
    }
}
