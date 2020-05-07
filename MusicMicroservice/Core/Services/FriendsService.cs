using Common.Shared;
using Core.DTO;
using Core.Interfaces.Services;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using Persistence.DAL;
using System;
using System.Collections.Generic;
using System.Text;

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
        }

        public List<FriendDTO> GetAllPossibleFriends(Guid userId)
        {
        }

        public (int, List<FriendDTO>) GetFriends(FriendsPageFilter filter)
        {
            //var query = _context.Friendships.Where(f => f.FirstFriendId == filter.UserId).Include(f => f.SecondFriend)
            //   .ThenInclude(fr => fr.Library);

            //int totalNumber = query.Count();

            //var friends = query.Skip(filter.PageIndex * filter.PageSize).Take(filter.PageSize).Select(f => FriendCoreConverter.ToDTO(f.SecondFriend, true)).ToList();
            //return (totalNumber, friends);
            var user = usersDbList.Find(u => u.Id == filter.UserId).FirstOrDefault();

            var friendsIds = user.FriendsIds;

            var totalNumber = friendsIds.Count;

            var queryableUsers = usersDbList.AsQueryable();
            var queryableLibraries = libraryDbList.AsQueryable();



            //var library = from lib in libraryDbList.AsQueryable()
            //              join u in queryableUsers on lib.Id equals u.LibraryId
            //              where u.Id == filter.UserId
            //              select lib.SongsIds;



            var queryResult = from u in usersDbList.AsQueryable()
                              join l in queryableLibraries on u.LibraryId equals libraryDbList.Id
                        where friendsIds.Contains(u.Id)
                        orderby (u.Name)
                        select new FriendDTO()
                        {
                            Id = u.Id,
                            Name = u.Name,
                            Age = u.Name,
                            LibraryName = l.LibraryNamem,
                            IsFriend = true
                        }.ToList();



            var friends = (totalNumber,queryResult);



        }

        public void RemoveFriend(Guid userId, Guid friendId)
        {
        }
    }
}
