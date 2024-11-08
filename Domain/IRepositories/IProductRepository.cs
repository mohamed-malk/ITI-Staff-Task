using Domain.Enums;
using Domain.Models;
using System.Linq.Expressions;

namespace Domain.IRepositories
{
    public interface IProductRepository
    {
        Task Add(Product product);
        Task Delete(Product product);
        Task<IEnumerable<Product>> Get();
        Task<Product> Get(Guid id);
        Task<Product> Get(string name);
        Task<IEnumerable<Product>> Get(Category category);
        Task<IEnumerable<Product>> FilterBy(Func<Product, bool> filter);
    }
}
