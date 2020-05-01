using Common.Models;
using Grpc.Core;
using Grpc.Interfaces;
using MusicMicroservice;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Grpc.Services
{
    public class LibraryService : ILibraryService
    {
        const string channelTarget = "localhost:50052";

        public async Task AddLibraryAsync(LibraryAddModel library)
        {
            var channel = new Channel(channelTarget, ChannelCredentials.Insecure);
            try
            {
                var client = new LibraryGrpcService.LibraryGrpcServiceClient(channel);
                var request = new AddLibraryRequest()
                {
                    Id = library.Id.ToString(),
                    Name = library.Name
                };

                var response = await client.AddLibraryAsync(request);

                return;
            }
            finally
            {
                await channel.ShutdownAsync();
            }
        }
    }
}
