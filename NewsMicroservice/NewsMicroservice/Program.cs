using Core.Interfaces.Services;
using Core.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NewsMicroservice.Seeder;
using System;

namespace NewsMicroservice
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("---- News microservice is running -----");

            IServiceCollection services = new ServiceCollection();
            Startup startup = new Startup();
            startup.ConfigureServices(services);
            IServiceProvider serviceProvider = services.BuildServiceProvider();

            var service = serviceProvider.GetService<INewsService>();

            var appSeeder = new AppSeeder(service);
            appSeeder.SeedNews();
        }
    }


   
}

