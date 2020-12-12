using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Tienda.Distribucion.Applicacion.DTO
{
    public class OrdenEntregaDTO
    {

        public Guid Id { get; set; }
        public string NombreCliente { get; set; }
        public string Telefono { get; set; }

        public decimal LatitudDestino { get; set; }
        public decimal LongitudDestino { get; set; }

        public List<ItemEntregaDTO> Items { get; set; }

        public OrdenEntregaDTO()
        {
            Items = new List<ItemEntregaDTO>();
        }
    }
}
