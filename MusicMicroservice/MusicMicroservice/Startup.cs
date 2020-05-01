using System;
using System.Collections.Generic;
using System.Text;
using Core.Interfaces.Services;
using Core.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MusicMicroservice.Seeder;

namespace MusicMicroservice
{
    public class Startup
    {
        public Startup()
        {
            var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json");

            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(Configuration);
            services.AddSingleton<IUsersService,UsersService>();
            services.AddSingleton<ILibraryService, LibraryService>();
            services.AddSingleton<AppSeeder, AppSeeder>();
        }
    }
}
