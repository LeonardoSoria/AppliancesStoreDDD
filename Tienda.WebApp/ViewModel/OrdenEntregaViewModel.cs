using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tienda.WebApp.ViewModel
{
    public class OrdenEntregaViewModel
    {
        public string NombreCliente { get; set; }
        public string Telefono { get; set; }

        public decimal LatitudDestino { get; set; }
        public decimal LongitudDestino { get; set; }

        public List<ItemEntregaViewModel> Items { get; set; }

        public OrdenEntregaViewModel()
        {
            Items = new List<ItemEntregaViewModel>();
        }
    }
}
