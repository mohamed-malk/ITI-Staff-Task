using Domain.Enums;
using Domain.Models;
using Service.Abstraction;

namespace ITI_Staff_Task.Views
{
    /// <summary>
    /// Represent the Product View in Console APP
    /// </summary>
    public class ProductScreen
    {
        private readonly IAdminService _service;

        public ProductScreen(IAdminService service)
        {
            _service = service;
        }

        private Category ConvertCategory(string categoryName)
        {
            return (Category)Enum.Parse(typeof(Category), categoryName);
        }

        /// <summary>
        /// Display the Data of <paramref name="product"/>
        /// </summary>
        /// <param name="product"></param>
        private void Show(Product product)
        {
            Console.Write($"Category is {product.Category} \n");
            Console.Write($"Name is {product.Name} \n");
            Console.Write($"Price is {product.Price} \n");
            Console.Write($"Quantity is {product.StockQuantity} \n");
            Console.Write($"Inventory is {product.Inventory} \n");
        }

        /// <summary>
        /// Display the Section of Fetching Data from User
        /// </summary>
        public async Task Add()
        {
            Console.Write($"Select Category {Home.ShowCategories()} : ");
            Category category = ConvertCategory(Console.ReadLine()!);
            Console.Write($"Name : ");
            string name = Console.ReadLine()!;
            Console.Write($"Price : ");
            double price = double.Parse(Console.ReadLine()!);
            Console.Write($"Quantity : ");
            int quantity = int.Parse(Console.ReadLine()!);

            var product = await _service.ProductService.CreateProduct(category, name, price, quantity);
            Console.Write($"\n\t\t\t\t ----------------------------------------- \n");
            Show(product); 
            Console.Write(Utility.BreakLine);
        }

        /// <summary>
        /// Display List the Data of <see cref="Product"/>
        /// </summary>
        public async Task Show()
        {
            var products = await _service.ProductService.GetAll();
            foreach (var product in products)
            {
                Show(product);
                Console.Write($"\n\t\t\t\t ----------------------------------------- \n");
            }
            Console.WriteLine($"Total Inventory = {_service.ProductService.TotalInventory}");
            Console.Write(Utility.BreakLine);
        }

        /// <summary>
        /// Display the Section of Changing Quantity of <see cref="Product"/>
        /// </summary>
        public async Task ChangeQuantity()
        {
            Console.Write($"Name : ");
            string name = Console.ReadLine()!;

            Console.Write($"Adding Quantity : ");
            int quantity = int.Parse(Console.ReadLine()!);

            var product = await _service.ProductService.ChangeQuantity(name, quantity);

            Console.Write($"\n\t\t\t\t ----------------------------------------- \n");
            Show(product);
            Console.Write(Utility.BreakLine);
        }
    }
}
