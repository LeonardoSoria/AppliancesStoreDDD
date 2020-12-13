using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Tienda.Distribucion.Domain.Model.Disitribucion;

namespace Tienda.Distribucion.Applicacion.DTO
{
    public class OrdenEntregaDTO
    {

        public Guid Id { get; set; }
        public string NombreCliente { get; set; }
        public string Telefono { get; set; }
        public decimal LatitudDestino { get; set; }
        public decimal LongitudDestino { get; set; }
        public EstadoOrdenEntrega Estado { get; set; }
        public List<ViajeEntregaDTO> Viajes { get; set; }
        public List<ItemEntregaDTO> Items { get; set; }

        public OrdenEntregaDTO()
        {
            Items = new List<ItemEntregaDTO>();
            Viajes = new List<ViajeEntregaDTO>();
        }
    }
}
