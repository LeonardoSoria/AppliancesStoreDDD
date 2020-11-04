using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using Tienda.Distribucion.Domain.ValueObjects.Rules;
using Tienda.SharedKernel.Core;

namespace Tienda.Distribucion.Domain.ValueObjects
{
    public class LongitudGps : ValueObject, IComparable<LatitudGps>
    {
        public decimal Value { get; private set; }

        public LongitudGps(decimal value)
        {
            CheckRule(new LongitudRule(value));

            Value = value;
        }

        public int CompareTo([AllowNull] LatitudGps other)
        {
            return Value.CompareTo(other);
        }

        #region Conversion

        public static implicit operator decimal(LongitudGps value) => value.Value;

        public static implicit operator LongitudGps(decimal value) => new LongitudGps(value);

        #endregion
    }
}
