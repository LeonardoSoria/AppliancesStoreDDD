using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using Tienda.Distribucion.Applicacion.DTO;

namespace Tienda.Distribucion.Applicacion.Features.OrdenEntrega.InsertOrdenEntrega
{
    public class InsertOrdenEntregaCommand : IRequest<VoidResult>
    {
        public Guid Id { get; set; }
        public string NombreCliente { get; set; }
        public string Telefono { get; set; }

        public decimal LatitudDestino { get; set; }
        public decimal LongitudDestino { get; set; }

        public List<ItemEntregaDTO> Items { get; set; }

        public InsertOrdenEntregaCommand()
        {
            Items = new List<ItemEntregaDTO>();
        }
    }
}
