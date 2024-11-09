using Domain.Enums;
using Domain.Exceptions;
using Domain.IRepositories;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly DbSet<Product> _products;
        public ProductRepository(ApplicationContext context)
        {
            _products = context.Set<Product>();
        }

        private Task<Product> GetProduct(Product? product, object by)
        {
            if (product is null)
                throw new NotFoundException($"{by} Product");
            return Task.FromResult(product);
        }


        public async Task Add(Product product)
        {
            try
            {
                await Get(product.Name);
                throw new AlreadyExistException(product.Name);
            }
            catch (NotFoundException)
            {
                await _products.AddAsync(product);
            }
        }

        public Task Delete(Product product)
        {
            _products.Remove(product);
            return Task.CompletedTask;
        }

        public Task<IEnumerable<Product>> FilterBy(Func<Product, bool> filter)
        {
            var product = _products.Where(filter);
            return Task.FromResult(product);
        }

        public Task<IEnumerable<Product>> Get()
        {
            return Task.FromResult<IEnumerable<Product>>
                (_products.ToList());
        }

        public async Task<Product> Get(Guid id)
        {
            var product = await _products.FindAsync(id);
            return await GetProduct(product, id);
        }

        public async Task<Product> Get(string name)
        {
            var product = await _products.SingleOrDefaultAsync(p => p.Name.Equals(name));
            return await GetProduct(product, name);
        }

        public async Task<IEnumerable<Product>> Get(Category category)
        {
            var products = _products.Where(p => p.Category.Equals(category));
            return await products.ToListAsync();
        }
    }
}
