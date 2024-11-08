using Domain.Enums;
using Domain.Models;

namespace Service.Abstraction
{
    public interface IProductService
    {
        Task<Product> ChangeQuantity(string name, int addingQuantity);
        Task<Product> CreateProduct(Category category, string name, double price, int quantity);
        Task<IEnumerable<Product>> GetByCategory(Category category);
        Task<IEnumerable<Product>> GetAll();
    }
}
