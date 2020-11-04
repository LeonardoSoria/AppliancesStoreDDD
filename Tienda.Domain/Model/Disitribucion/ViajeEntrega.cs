using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;
using Tienda.Distribucion.Domain.Model.Disitribucion.Id;
using Tienda.SharedKernel.Core;

namespace Tienda.Distribucion.Domain.Model.Disitribucion
{
    public class ViajeEntrega : Entity
    {
        public Guid ViajeId { get; private set; }

        public OrdenEntrega OrdenEntrega { get; private set; }

        public DateTime FechaProgramado { get; private set; }

        public DateTime? FechaInicioViaje { get; private set; }
        public DateTime? FechaFinViaje { get; private set; }

        private List<SeguimientoViajeItem> _itemsSeguimiento;

        public ImmutableList<SeguimientoViajeItem> ItemsSeguimiento
        {
            get
            {
                return _itemsSeguimiento.ToImmutableList<SeguimientoViajeItem>();
            }
        }

        public ViajeEntrega(OrdenEntrega ordenEntrega, 
            DateTime fechaProgramado)
        {
            ViajeId = Guid.NewGuid();
            OrdenEntrega = ordenEntrega;
            FechaProgramado = fechaProgramado;
            FechaInicioViaje = null;
            FechaFinViaje = null;

            _itemsSeguimiento = new List<SeguimientoViajeItem>();
        }

        protected ViajeEntrega() { }

        public void InsertarItemSeguimiento(decimal latitud, decimal longitud)
        {
            SeguimientoViajeItem item = new SeguimientoViajeItem(latitud, longitud);
            _itemsSeguimiento.Add(item);
        }


    }
}
