using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Models;
using Common.Shared;
using Grpc.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MicroservicesWebApi.Controllers
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
            return _friendsService.GetAllPossibleFriendsAsync(userId).Result;
        }

        [HttpPost]
        public void RemoveFriend(AddRemoveFriendModel model)
        {
            _friendsService.RemoveFriendAsync(model.UserId, model.FriendId);
        }

        [HttpPost]
        public void AddFriend(AddRemoveFriendModel model)
        {
            _friendsService.AddFriendAsync(model.UserId, model.FriendId);
        }


        [HttpPost]
        public FriendsPageModel GetFriends(FriendsPageFilter filter)
        {
            return _friendsService.GetFriendsAsync(filter).Result;
        }
    }
}