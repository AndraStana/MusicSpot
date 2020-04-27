using Core.Interfaces.Services;
using Core.Services;
using Grpc.Core;
using Grpc.GrpcServicesImplementations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NewsMicroservice.Seeder;
using System;
using System.Threading;
using System.Threading.Tasks;

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



            const string DefaultHost = "localhost";
            const int Port = 50051;

            var server = new Server
            {
                Services = { NewsGrpcService.BindService(new NewsGrpcServiceImpl(service)),


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

