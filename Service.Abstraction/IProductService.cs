using Domain.Enums;
using Domain.Models;

namespace Service.Abstraction
{
    /// <summary>
    /// Represent the Mapping of Product between Repositories  
    ///  and Presentation(Client)
    /// </summary>
    public interface IProductService
    {
        double TotalInventory { get; }

        /// <summary>
        /// Change the <see cref="Product.StockQuantity"/>
        /// </summary>
        /// <param name="name"><see cref="Product.Name"/></param>
        /// <param name="addingQuantity">The new Quantity that will be added to <see cref="Product.StockQuantity"/></param>
        /// <returns>The Updated <see cref="Product"/></returns>
        Task<Product> ChangeQuantity(string name, int addingQuantity);

        /// <summary>
        /// Create and Add new <see cref="Product"/>
        /// </summary>
        /// <param name="category"><see cref="Product.Category"/></param>
        /// <param name="name"><see cref="Product.Name"/></param>
        /// <param name="price"><see cref="Product.Price"/></param>
        /// <param name="quantity"><see cref="Product.StockQuantity"/></param>
        /// <returns>The new <see cref="Product"/></returns>
        Task<Product> CreateProduct(Category category, string name, double price, int quantity);
        Task<IEnumerable<Product>> GetByCategory(Category category);

        /// <summary>
        /// Get All Products of a Category
        /// </summary>
        /// <param name="category">Category</param>
        /// <returns><see cref="IEnumerable{Product}"/>  </returns>
        Task<IEnumerable<Product>> GetAll();
    }
}
