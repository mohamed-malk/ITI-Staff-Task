using Domain.Models;

namespace Service.Extenstions
{
    public static class ProductExtenstion
    {
        public static double GetTotalInventory(this IEnumerable<Product> products) =>
            products.Sum(p => p.StockQuantity);
        
    }
}
