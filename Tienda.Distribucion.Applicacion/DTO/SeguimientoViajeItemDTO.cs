using System;
using System.Collections.Generic;
using System.Text;

namespace Tienda.Distribucion.Applicacion.DTO
{
    public class SeguimientoViajeItemDTO
    {
        public Guid Id { get; set; }
        public DateTime FechaHora { get; set; }
        public decimal Latitud { get; set; }
        public decimal Longitud { get; set; }
        public ViajeEntregaDTO ViajeEntrega { get; set; }
    }
}
