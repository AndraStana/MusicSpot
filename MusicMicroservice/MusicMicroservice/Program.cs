using Core.Interfaces.Services;
using Grpc.Core;
using Grpc.ServicesImplementations;
using Microsoft.Extensions.DependencyInjection;
using MusicMicroservice.Seeder;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MusicMicroservice
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("---- Music microservice is running -----");

            IServiceCollection services = new ServiceCollection();
            Startup startup = new Startup();
            startup.ConfigureServices(services);
            IServiceProvider serviceProvider = services.BuildServiceProvider();

            var libraryService = serviceProvider.GetService<ILibraryService>();
            var usersService = serviceProvider.GetService<IUsersService>();
            var artistsService = serviceProvider.GetService<IArtistsService>();


            var appSeeder = serviceProvider.GetService<AppSeeder>();
            appSeeder.SeedAll();

            //var appSeeder = new AppSeeder(service);
            //appSeeder.SeedNews();


            const string DefaultHost = "localhost";
            const int Port = 50052;

            var server = new Server
            {
                Services = { LibraryGrpcService.BindService(new LibraryGrpcServiceImpl(libraryService)),
                            UsersGrpcService.BindService(new UsersGrpcServiceImpl(usersService)),
                            ArtistsGrpcService.BindService(new ArtistsGrpcServiceImpl(artistsService)),

                },
                Ports = { new ServerPort(DefaultHost, Port, ServerCredentials.Insecure) }
            };

            CancellationTokenSource tokenSource = new CancellationTokenSource();
            var serverTask = RunServiceAsync(server, tokenSource.Token);

            Console.WriteLine("Server listening on port " + Port);
            Console.WriteLine("Press any key to stop the server...");
            Console.ReadKey();

            tokenSource.Cancel();
            Console.WriteLine("Shutting down...");
            serverTask.Wait();



            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }


        private static async Task RunServiceAsync(Server server, CancellationToken cancellationToken = default(CancellationToken))
        {
            server.Start();

            await AwaitCancellation(cancellationToken);
            await server.ShutdownAsync();
        }

        private static Task AwaitCancellation(CancellationToken token)
        {
            var taskSource = new TaskCompletionSource<bool>();
            token.Register(() => taskSource.SetResult(true));
            return taskSource.Task;
        }
    }
}

