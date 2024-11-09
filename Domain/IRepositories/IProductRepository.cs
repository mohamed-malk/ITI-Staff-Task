using Domain.Enums;
using Domain.Models;

namespace Domain.IRepositories
{
    /// <summary>
    /// Represent the Operations on Product Entity with Data Source 
    /// {DB or Memory}
    /// </summary>
    public interface IProductRepository
    {
        /// <summary>
        /// Add New Product
        /// </summary>
        /// <param name="product">New <see cref="Product"/> object</param>
        /// <returns></returns>
        Task Add(Product product);
        
        /// <summary>
        /// Delete Product
        /// </summary>
        /// <param name="product">Existing <see cref="Product"/> object</param>
        /// <returns></returns>
        Task Delete(Product product);
       
        /// <summary>
        /// Get All Products from Data Source
        /// </summary>
        /// <returns><see cref="IEnumerable{Product}"/>  </returns>
        Task<IEnumerable<Product>> Get();

        /// <summary>
        /// Get Particular <see cref="Product"/> 
        /// </summary>
        /// <param name="id">Unique Identifier for <see cref="Product"/></param>
        /// <returns><seealso cref="Product"/></returns>
        Task<Product> Get(Guid id);
        
        /// <summary>
        /// Get Particular <see cref="Product"/> 
        /// </summary>
        /// <param name="name">Name <see cref="Product"/></param>
        /// <returns><seealso cref="Product"/> that its name equal to <paramref name="name"/> (Unique)</returns>
        Task<Product> Get(string name);

        /// <summary>
        /// Get All Products of a Category
        /// </summary>
        /// <param name="category">Category</param>
        /// <returns><see cref="IEnumerable{Product}"/>  </returns>
        Task<IEnumerable<Product>> Get(Category category);

        /// <summary>
        /// Get All Products that match the <paramref name="filter"/> Criteria
        /// </summary>
        /// <param name="filter">Criteria that retrieve Particular Products</param>
        /// <returns><see cref="IEnumerable{Product}"/>  </returns>
        Task<IEnumerable<Product>> FilterBy(Func<Product, bool> filter);
    }
}
