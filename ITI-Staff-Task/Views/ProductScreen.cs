using Domain.Enums;
using Domain.Models;
using Service.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI_Staff_Task.Views
{
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

        private void Show(Product product)
        {
            Console.Write($"Category is {product.Category} \n");
            Console.Write($"Name is {product.Name} \n");
            Console.Write($"Price is {product.Price} \n");
            Console.Write($"Quantity is {product.StockQuantity} \n");
            Console.Write($"Inventory is {product.Inventory} \n");
        }

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
        public async Task Show()
        {
            var products = await _service.ProductService.GetAll();
            foreach (var product in products)
            {
                Show(product);
                Console.Write($"\n\t\t\t\t ----------------------------------------- \n");
            }
            Console.Write(Utility.BreakLine);
        }
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
