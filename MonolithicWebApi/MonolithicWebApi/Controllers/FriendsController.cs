using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Interfaces.Services;
using Common.Shared;
using Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using MonolithicWebApi.Converters;
using MonolithicWebApi.Models;

namespace MonolithicWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class FriendsController : ControllerBase
    {
        private readonly IFriendsService _friendsService;


        public FriendsController(IFriendsService friendsService)
        {
            _friendsService = friendsService;
        }

        [HttpGet]
        public List<FriendModel> GetAllPossibleFriends([FromQuery] Guid userId)
        {
            var friends = _friendsService.GetAllPossibleFriends(new FriendsDialogFilter() { UserId = userId } );

            return  friends.Select(s => FriendWebConverter.ToModel(s)).ToList();
        }

        [HttpPost]
        public void RemoveFriend(AddRemoveFriendModel model)
        {
            _friendsService.RemoveFriend(model.UserId, model.FriendId);
        }

        [HttpPost]
        public void AddFriend(AddRemoveFriendModel model)
        {
            _friendsService.AddFriend(model.UserId, model.FriendId);
        }


        [HttpPost]
        public FriendsPageModel GetFriends(FriendsPageFilter filter)
        {
            var (totaNumber, friends) = _friendsService.GetFriends(filter);

            return new FriendsPageModel()
            {
                Friends = friends.Select(s => FriendWebConverter.ToModel(s)).ToList(),
                TotalNumber = totaNumber
            };

        }
    }
}