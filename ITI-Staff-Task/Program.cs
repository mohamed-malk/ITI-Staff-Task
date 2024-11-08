using Domain.IRepositories;
using Infrastructure.Repositories;
using ITI_Staff_Task.Views;
using Service;
using Service.Abstraction;

namespace ITI_Staff_Task;
    internal class Program
    {
        static async Task Main(string[] args)
        {
            IAdminRepository repository = new AdminRepository();
            IAdminService service = new AdminService(repository);
            ProductScreen screen = new ProductScreen(service);

            Home.Menue();

            while (true)
            {
                var key = Console.ReadKey();
            try
            {
                switch (key.Key)
                {
                    case ConsoleKey.A:
                        await screen.Add();
                        break;
                    case ConsoleKey.S:
                        await screen.Show();
                        break;
                    case ConsoleKey.Q:
                        await screen.ChangeQuantity();
                        break;
                    case ConsoleKey.E:
                        break;
                    default:
                        Home.Menue();
                        break;
                }
            }
            catch (Exception ex)
            {
                Home.HandleException(ex);
                Home.Menue();
            }
            if (key.Key == ConsoleKey.E)
                break;
            }

        }
    }
