using Domain.IRepositories;
using Infrastructure.Repositories;
using ITI_Staff_Task.Views;
using Service;
using Service.Abstraction;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Infrastructure;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace ITI_Staff_Task;
internal class Program
{
    static async Task Main(string[] args)
    {

        string connection = "Data Source=MUSTAFA-YASSER; Database=ITI-Staff-Task;Integrated Security=True;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False";
        var serviceCollection = new ServiceCollection();

        serviceCollection.AddDbContext<ApplicationContext>(options =>
        options.UseSqlServer(connection,
        b =>
        {
            b.MigrationsAssembly("Infrastructure");
        }), ServiceLifetime.Scoped
        );

        serviceCollection.AddScoped<IAdminRepository, AdminRepository>();
        serviceCollection.AddScoped<IAdminService, AdminService>();

        var serviceProvider = serviceCollection.BuildServiceProvider();
        IAdminService service = serviceProvider.GetService<IAdminService>() ?? throw new Exception();
        ProductScreen screen = new ProductScreen(service);

        // Start the APP
        Home.Menu();

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
                        Home.Menu();
                        break;
                }
            }
            catch (Exception ex)
            {
                Home.HandleException(ex);
                Home.Menu();
            }
            if (key.Key == ConsoleKey.E)
                break;
        }

    }
}
