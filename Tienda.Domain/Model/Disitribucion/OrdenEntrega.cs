using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Collections.ObjectModel;
using System.Text;
using Tienda.Distribucion.Domain.Model.Disitribucion.Id;
using Tienda.Distribucion.Domain.Model.Disitribucion.Rules;
using Tienda.Distribucion.Domain.ValueObjects;
using Tienda.SharedKernel.Core;
using Tienda.SharedKernel.ValueObjects;
using Tienda.SharedKernel.ValueObjects.PhoneNumber;

namespace Tienda.Distribucion.Domain.Model.Disitribucion
{
    public class OrdenEntrega : Entity, IAggregateRoot
    {
        public Guid Id { get; private set; }
        public DateTime FechaRegistro { get; private set; }
        public DateTime? FechaConsolidacion { get; private set; }
        public DateTime? FechaAnulacion { get; private set; }
        public DateTime? FechaFinalizacion { get; private set; }

        public EstadoOrdenEntrega Estado { get; private set; }
        public PersonNameValue NombreCliente { get; private set; }
        public PhoneNumberValue Telefono { get; private set; }

        public LatitudGps LatitudDestino { get; private set; }
        public LongitudGps LongitudDestino { get; private set; }

        private List<ViajeEntrega> _viajes;

        public ImmutableList<ViajeEntrega> Viajes {
            get 
            {
                return _viajes.ToImmutableList<ViajeEntrega>();
            }
        }

        private List<ItemEntrega> _items;

        public ImmutableList<ItemEntrega> Items
        {
            get
            {
                return _items.ToImmutableList<ItemEntrega>();
            }
        }

        public OrdenEntrega( 
            string nombreCliente, 
            string telefono, 
            decimal latitudDestino, 
            decimal longitudGps,
            ICollection<ItemEntrega> items)
        {
            Id = Guid.NewGuid();
            FechaRegistro = DateTime.Now;
            NombreCliente = nombreCliente;
            Telefono = telefono;
            LatitudDestino = latitudDestino;
            LongitudDestino = longitudGps;
            Estado = EstadoOrdenEntrega.Pendiente;

            _viajes = new List<ViajeEntrega>();
            _items = new List<ItemEntrega>();

            foreach (var item in items)
            {
                item.OrdenEntrega = this;
                _items.Add(item);
            }
        }

        protected OrdenEntrega() { }

        public void ConsolidarOrdenEntrega()
        {
            CheckRule(new ChangeOrderStatusRule(Estado, EstadoOrdenEntrega.ListoParaEntrega));
            FechaConsolidacion = DateTime.Now;
            Estado = EstadoOrdenEntrega.ListoParaEntrega;
        }

        public void FinalizarEntrega()
        {
            CheckRule(new ChangeOrderStatusRule(Estado, EstadoOrdenEntrega.Finaliado));
            FechaFinalizacion = DateTime.Now;
            Estado = EstadoOrdenEntrega.Finaliado;
        }

        public void AnularEntrega()
        {
            CheckRule(new ChangeOrderStatusRule(Estado, EstadoOrdenEntrega.Anulado));
            FechaAnulacion = DateTime.Now;
            Estado = EstadoOrdenEntrega.Anulado;
        }

        

    }
}
