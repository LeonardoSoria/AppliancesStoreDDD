using System;
using System.Collections.Generic;
using System.Text;
using Tienda.Distribucion.Domain.Model.Disitribucion.Id;
using Tienda.SharedKernel.Core;

namespace Tienda.Distribucion.Domain.Model.Disitribucion
{
    public class ItemEntrega : Entity
    {
        public Guid Id { get; private set; }
        public OrdenEntrega OrdenEntrega { get; set; }
        public string Codigo { get; private set; }
        public string Descripcion { get; private set; }

        public ItemEntrega(string codigo, string descripcion)
        {
            CheckRule(new NotNullRule<string>(codigo));
            CheckRule(new NotNullRule<string>(descripcion));

            Id = Guid.NewGuid();
            Codigo = codigo;
            Descripcion = descripcion;
        }

        protected ItemEntrega() { }
    }
}
