using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tienda.Soporte.Domain.Model.Soporte;
using Tienda.Soporte.Domain.Persistence.Repository;

namespace Tienda.Soporte.Infraestructura.Persistence.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Delete(Guid productId)
        {
            Product obj = await _context.Products.Where(x => x.ProductId == productId).FirstOrDefaultAsync();
            _context.Products.Remove(obj);
            await _context.SaveChangesAsync();
        }

        public async Task<Product> GetProductById(Guid productId)
        {
            Product obj = await _context.Products.Where(x => x.ProductId == productId).FirstOrDefaultAsync();
            return obj;
        }

        public async Task<List<Product>> GetProducts()
        {
            List<Product> productsList = await _context.Products.ToListAsync();
            return productsList;
        }

        public async Task Insert(Product product)
        {
            await _context.Products.AddAsync(product);
        }

        public async Task<Product> Update(Guid productId, Product product)
        {
            Product obj = await _context.Products.Where(x => x.ProductId == product.ProductId).FirstOrDefaultAsync();
            _context.Entry(obj).CurrentValues.SetValues(product);
            await _context.SaveChangesAsync();
            return product;
        }
    }
}
