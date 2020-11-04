using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tienda.Soporte.Domain.Model.Soporte;

namespace Tienda.Soporte.Domain.Persistence.Repository
{
    public interface IProductRepository
    {
        Task<List<Product>> GetProducts();

        Task<Product> GetProductById(Guid productId);

        Task Insert(Product product);

        Task<Product> Update(Guid productId, Product product);

        Task Delete(Guid productId);
    }
}
