using Domain.Enums;
using Domain.Exceptions;
using Domain.IRepositories;
using Domain.Models;
using Service.Abstraction;
using Service.Extenstions;

namespace Service
{
    public class ProductService : IProductService
    {
        private readonly IAdminRepository _adminRepository;

        public ProductService(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }

        public double TotalInventory => _adminRepository.ProductRepository
            .Get().Result.GetTotalInventory();

        public async Task<Product> CreateProduct(Category category, string name, double price, int quantity)
        {
            Product product = new()
            {
                Category = category,
                Name = name,
                Price = price,
                StockQuantity = quantity
            };
            await _adminRepository.ProductRepository.Add(product);

            return product;
        }

        public async Task<IEnumerable<Product>> GetByCategory(Category category)
        {
            return await _adminRepository
                .ProductRepository.Get(category);
        }

        public async Task<Product> ChangeQuantity(string name, int addingQuantity)
        {
            var product = await _adminRepository.ProductRepository.Get(name);
            
            var newQuantity = product.StockQuantity + addingQuantity;
            if (newQuantity < 0)
                throw new NotAllowedException("The new Quantity will be negative");
           
            product.StockQuantity = newQuantity;
            return product;
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _adminRepository.ProductRepository.Get();
        }
    }
}
