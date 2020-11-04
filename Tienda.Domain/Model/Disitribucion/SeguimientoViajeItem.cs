using System;
using System.Collections.Generic;
using System.Text;
using Tienda.Distribucion.Domain.Model.Disitribucion.Id;
using Tienda.Distribucion.Domain.ValueObjects;
using Tienda.SharedKernel.Core;

namespace Tienda.Distribucion.Domain.Model.Disitribucion
{
    public class SeguimientoViajeItem : Entity
    {
        public Guid Id { get; set; }
        public DateTime FechaHora { get; private set; }
        public LatitudGps Latitud { get; private set; }
        public LongitudGps Longitud { get; private set; }
        public ViajeEntrega Viaje { get; set; }

        public SeguimientoViajeItem(decimal latitud, decimal longitud)
        {
            Id = Guid.NewGuid();
            FechaHora = DateTime.Now;
            Latitud = latitud;
            Longitud = longitud;
        }

        protected SeguimientoViajeItem() { }
    }
}
