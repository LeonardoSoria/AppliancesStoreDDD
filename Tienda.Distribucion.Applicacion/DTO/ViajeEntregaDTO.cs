using System;
using System.Collections.Generic;
using System.Text;

namespace Tienda.Distribucion.Applicacion.DTO
{
    public class ViajeEntregaDTO
    {
        public Guid Id { get; set; }
        public OrdenEntregaDTO OrdenEntrega { get; set; }
        public DateTime FechaProgramado { get; set; }
        public DateTime? FechaInicioViaje { get; set; }
        public DateTime? FechaFinViaje { get; set; }
    }
}
