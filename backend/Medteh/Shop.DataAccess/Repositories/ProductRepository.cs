using Shop.Core.Models;
using System.Data.Entity;
using Shop.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Shop.DataAccess.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ShopDBContext _context;
        public ProductRepository(ShopDBContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> Get()
        {
            var productEntities = await EntityFrameworkQueryableExtensions
                .AsNoTracking(_context.Products)
                .ToListAsync();

            var products = productEntities.Select(b => Product.Create(b.Id, b.Title, b.Description, b.Price).Product).ToList();

            return products;
        }

        public async Task<Guid> Create(Product product)
        {
            var productEntity = new ProductEntity
            {
                Id = product.Id,
                Title = product.Title,
                Description = product.Description,
                Price = product.Price,
            };
            await _context.Products.AddAsync(productEntity);
            await _context.SaveChangesAsync();

            return productEntity.Id;
        }

        public async Task<Guid> Update(Guid id, string title, string descriprion, decimal price)
        {
            await _context.Products.Where(b => b.Id == id).ExecuteUpdateAsync(s => s.SetProperty(b => b.Title, b => title).SetProperty(b => b.Description, b => descriprion).SetProperty(b => b.Price, b => price));

            return id;
        }

        public async Task<Guid> Delete(Guid id)
        {
            await _context.Products.Where(b=>b.Id == id).ExecuteDeleteAsync();

            return id;
        }
    }


}
