using Domain.Enums;
using Domain.Exceptions;
using Domain.IRepositories;
using Domain.Models;

namespace Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ICollection<Product> _products;
        public ProductRepository()
        {
            _products = new List<Product>() { new() { Category = Category.Phone, Name = "Test", Price = 1000, StockQuantity = 10 } };
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
                _products.Add(product);
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

        public Task<Product> Get(Guid id)
        {
            var product = _products.SingleOrDefault(p => p.Id.Equals(id));
            return GetProduct(product, id);
        }

        public Task<Product> Get(string name)
        {
            var product = _products.SingleOrDefault(p => p.Name.Equals(name));
            return GetProduct(product, name);
        }

        public Task<IEnumerable<Product>> Get(Category category)
        {
            var products = _products.Where(p => p.Category.Equals(category));
            return Task.FromResult(products);
        }
    }
}
