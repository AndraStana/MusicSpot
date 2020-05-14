using Common.Shared;
using Core.DTO;
using Core.Interfaces.Services;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using Persistence.DAL;
using System;
using System.Collections.Generic;

using System.Linq;

namespace Core.Services
{
    public class FriendsService : IFriendsService
    {
        private readonly IMongoCollection<User> usersDbList;
        private readonly IMongoCollection<Library> libraryDbList;


        public FriendsService(IConfiguration config)
        {
            MongoClient client = new MongoClient(config["ConnectionStrings:DefaultConnection"]);

            IMongoDatabase database = client.GetDatabase("MusicSpotMusic");
            usersDbList = database.GetCollection<User>("Users");
            libraryDbList = database.GetCollection<Library>("Libraries");

        }


        public void AddFriend(Guid userId, Guid friendId)
        {
            var filter = Builders<User>.Filter.Eq(x => x.Id, userId);
            var update = Builders<User>.Update.AddToSet("FriendsIds", friendId);

            usersDbList.UpdateOne(filter, update);
        }

        public List<FriendDTO> GetAllPossibleFriends(Guid userId)
        {

            //var allUsers = _context.Users.Include(u => u.FirstFriends).ToList();

            //var user = allUsers.FirstOrDefault(u => u.Id == filter.UserId);

            //var friendsIds = user.FirstFriends.Select(f => f.SecondFriendId).ToList();

            //var allPossibleFriends = allUsers.Where(u => u.Id != filter.UserId)
            //    .Select(u => FriendCoreConverter.ToDTO(u, friendsIds.Contains(u.Id))).ToList();

            //return allPossibleFriends;



            var user = usersDbList.Find(u => u.Id == userId).FirstOrDefault();

            var friendsIds = user.FriendsIds;

            var queryableUsers = usersDbList.AsQueryable();
            var queryableLibraries = libraryDbList.AsQueryable();


            var queryResult = from u in usersDbList.AsQueryable()
                              join l in queryableLibraries on u.LibraryId equals l.Id
                              where u.Id != userId
                              orderby (u.Username)
                              select new FriendDTO()
                              {
                                  Id = u.Id,
                                  Name = u.Username,
                                  Age = DateTime.Now.Year - u.YearOfBirth,
                                  LibraryName = l.Name,
                                  IsFriend = friendsIds.Contains(u.Id)
                              };

            var friends =  queryResult.ToList();
            return friends;


            //var user = usersDbList.Find(u => u.Id == userId).FirstOrDefault();

            //var friendsIds = user.FriendsIds;


            //var queryableUsers = usersDbList.AsQueryable();
            //var queryableLibraries = libraryDbList.AsQueryable();


            //var queryResult = from u in usersDbList.AsQueryable()
            //                  join l in queryableLibraries on u.LibraryId equals l.Id
            //                  where friendsIds.Contains(u.Id)
            //                  orderby (u.Username)
            //                  select new FriendDTO()
            //                  {
            //                      Id = u.Id,
            //                      Name = u.Username,
            //                      Age = DateTime.Now.Year - u.YearOfBirth,
            //                      LibraryName = l.Name,
            //                      IsFriend = false
            //                  };


            //var friends =  queryResult.ToList();
            //return friends;
        }

        public (int, List<FriendDTO>) GetFriends(FriendsPageFilter filter)
        {
         
            var user = usersDbList.Find(u => u.Id == filter.UserId).FirstOrDefault();

            var friendsIds = user.FriendsIds;

            var totalNumber = friendsIds.Count;

            var queryableUsers = usersDbList.AsQueryable();
            var queryableLibraries = libraryDbList.AsQueryable();


            var queryResult = from u in usersDbList.AsQueryable()
                              join l in queryableLibraries on u.LibraryId equals l.Id
                        where friendsIds.Contains(u.Id)
                        orderby (u.Username)
                        select new FriendDTO()
                        {
                            Id = u.Id,
                            Name = u.Username,
                            Age = DateTime.Now.Year - u.YearOfBirth,
                            LibraryName = l.Name,
                            IsFriend = true
                        };


            var friends = (totalNumber,queryResult.Skip(filter.PageIndex*filter.PageSize)
                .Take(filter.PageSize).ToList());
            return friends;

        }

        public void RemoveFriend(Guid userId, Guid friendId)
        {
            var filter = Builders<User>.Filter.Eq(x => x.Id, userId);
            var update = Builders<User>.Update.Pull("FriendsIds", friendId);

            usersDbList.UpdateOne(filter, update);
        }
    }
}
