using Domain.Enums;

namespace Domain.Models
{
    /// <summary>
    /// Product Entity
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Unique Identfier for an Entity
        /// </summary>
        public Guid Id => Guid.NewGuid();
        
        /// <summary>
        /// Product Name, Unique for a Pproduct
        /// </summary>
        public required string Name { get; set; }
        public required Category Category { get; set; }
        public required double Price { get; set; }
        public required int StockQuantity { get; set; }

        /// <summary>
        /// Total Price for Product
        /// </summary>
        public double Inventory => StockQuantity * Price;
    }
}
