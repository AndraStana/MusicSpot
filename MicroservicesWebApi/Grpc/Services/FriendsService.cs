using Common.Models;
using Common.Shared;
using Grpc.Core;
using Grpc.GrpcConverter;
using Grpc.Interfaces;
using MusicMicroservice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grpc.Services
{
    public class FriendsService : IFriendsService
    {
        const string channelTarget = "localhost:50052";

        public async Task<FriendsPageModel> GetFriendsAsync(FriendsPageFilter filter)
        {
            var channel = new Channel(channelTarget, ChannelCredentials.Insecure);
            try
            {
                var client = new FriendsGrpcService.FriendsGrpcServiceClient(channel);
                var request = new GetFriendsRequest()
                {
                    UserId = filter.UserId.ToString(),
                    PageIndex = filter.PageIndex,
                    PageSize = filter.PageSize
                };

                var response = await client.GetFriendsAsync(request);

                return new FriendsPageModel()
                {
                    TotalNumber = response.TotalNumber,
                    Friends = response.Friends.Select(f => FriendGrpcConverter.ToMessage(f)).ToList()
                };
            }
            finally
            {
                await channel.ShutdownAsync();
            }
        }


        public async Task<List<FriendModel>> GetAllPossibleFriendsAsync(Guid userId)
        {
            var channel = new Channel(channelTarget, ChannelCredentials.Insecure);
            try
            {

                var client = new FriendsGrpcService.FriendsGrpcServiceClient(channel);
                var request = new GetAllPossibleFriendsRequest()
                {
                    UserId = userId.ToString(),
                };

                var response = await client.GetAllPossibleFriendsAsync(request);

                return response.Friends.Select(f => FriendGrpcConverter.ToMessage(f)).ToList();
            }
            finally
            {
                await channel.ShutdownAsync();
            }

        }

        public async Task AddFriendAsync(Guid userId, Guid friendId)
        {
            var channel = new Channel(channelTarget, ChannelCredentials.Insecure);
            try
            {
                var client = new FriendsGrpcService.FriendsGrpcServiceClient(channel);
                var request = new AddFriendRequest()
                {
                    UserId = userId.ToString(),
                    FriendId = friendId.ToString()
                };

                var response = await client.AddFriendAsync(request);

                return;
            }
            finally
            {
                await channel.ShutdownAsync();
            }
        }

        public async Task RemoveFriendAsync(Guid userId, Guid friendId)
        {
            var channel = new Channel(channelTarget, ChannelCredentials.Insecure);
            try
            {
                var client = new FriendsGrpcService.FriendsGrpcServiceClient(channel);
                var request = new RemoveFriendRequest()
                {
                    UserId = userId.ToString(),
                    FriendId = friendId.ToString()
                };

                var response = await client.RemoveFriendAsync(request);

                return;
            }
            finally
            {
                await channel.ShutdownAsync();
            }
        }

    }
}
