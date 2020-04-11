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


        [HttpPost]

        public FriendsPageModel GetFriends([FromBody] FriendsPageFilter filter)
        {
            var (totaNumber, friends) = _friendsService.GetFriends(filter);

            return new FriendsPageModel()
            {
                Friends = friends.Select(s => FriendWebConverter.ToModel(s)).ToList(),
                TotalNumber = totaNumber
            };

            //var friends = new List<FriendModel>();

            //for (int i = 0; i < filter.PageSize; i++)
            //{

            //    var friend = new FriendModel()
            //    {
            //        Id = Guid.NewGuid(),
            //        Name = "Friend 1",
            //        Age = 20,
            //        LibraryName = "Friend1's Library"
            //    };
            //    friends.Add(friend);
            //}


            //return new FriendsPageModel()
            //{
            //    Friends = friends,
            //    TotalNumber = 100
            //};
        }
    }
}