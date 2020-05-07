using Common.Shared;
using Core.Interfaces.Services;
using Grpc.Core;
using Grpc.GrpcConverters;
using MusicMicroservice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grpc.ServicesImplementations
{
    public class FriendsGrpcServiceImpl : FriendsGrpcService.FriendsGrpcServiceBase
    {
        private IFriendsService _friendsService { get; set; }

        public FriendsGrpcServiceImpl(IFriendsService friendsService)
        {
            _friendsService = friendsService;
        }


        public override Task<GetFriendsResponse> GetFriends(GetFriendsRequest request, ServerCallContext context)
        {
            var filter = new FriendsPageFilter()
            {
                UserId = Guid.Parse(request.UserId),
                PageIndex = request.PageIndex,
                PageSize = request.PageSize

            };

            var (totalNumber, friends) = _friendsService.GetFriends(filter);
            var response = new GetFriendsResponse()
            {
                TotalNumber = totalNumber
            };
            response.Friends.AddRange(friends.Select(f => FriendGrpcConverter.ToMessage(f)).ToList());
            return Task.FromResult(response);
        }

        public override Task<GetAllPossibleFriendsResponse> GetAllPossibleFriends(GetAllPossibleFriendsRequest request, ServerCallContext context)
        {

            var friends = _friendsService.GetAllPossibleFriends(Guid.Parse(request.UserId));
            var response = new GetAllPossibleFriendsResponse();
          
            response.Friends.AddRange(friends.Select(f => FriendGrpcConverter.ToMessage(f)).ToList());
            return Task.FromResult(response);
        }

        public override Task<AddFriendResponse> AddFriend(AddFriendRequest request, ServerCallContext context)
        {
             _friendsService.AddFriend(Guid.Parse(request.UserId), Guid.Parse(request.FriendId));
            var response = new AddFriendResponse();

            return Task.FromResult(response);
        }


        public override Task<RemoveFriendResponse> RemoveFriend(RemoveFriendRequest request, ServerCallContext context)
        {
            _friendsService.RemoveFriend(Guid.Parse(request.UserId), Guid.Parse(request.FriendId));
            var response = new RemoveFriendResponse();

            return Task.FromResult(response);
        }
    }
}