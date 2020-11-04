using System;
using System.Collections.Generic;
using System.Text;
using Tienda.SharedKernel.Core;

namespace Tienda.Soporte.Domain.Model.Soporte
{
    public class Product : Entity, IAggregateRoot
    {
        public Guid ProductId { get; private set; }
        public string ProductBrand { get; private set; }
        public string ProductName { get; private set; }
        public double ProductPrice { get; private set; }

        public Product(string productBrand, string productName, double productPrice)
        {
            CheckRule(new NotNullRule<string>(productBrand));
            CheckRule(new NotNullRule<string>(productName));
            CheckRule(new NotNullRule<double>(ProductPrice));

            ProductId = Guid.NewGuid();
            ProductBrand = productBrand;
            ProductName = productName;
            ProductPrice = productPrice;
        }

        public Product(Guid productId)
        {
            ProductId = productId;
        }

        protected Product() { }
    }
}
