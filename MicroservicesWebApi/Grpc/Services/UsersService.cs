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
    public class UsersService : IUsersService
    {
        const string channelTarget = "localhost:50052";

        public async Task AddUserAsync(UserAddModel user)
        {
            var channel = new Channel(channelTarget, ChannelCredentials.Insecure);
            try
            {
                var client = new UsersGrpcService.UsersGrpcServiceClient(channel);
                var request = new AddUserRequest()
                {
                    Id = user.Id.ToString(),
                    Username = user.Username,
                    Email = user.Email,
                    YearOfBirth = user.YearOfBirth,
                    LibraryId = user.LibraryId.ToString()
                };

                var response = await client.AddUserAsync(request);

                return;
            }
            finally
            {
                await channel.ShutdownAsync();
            }
        }
    }
}
