using Common.Shared;
using Core.CoreConverters;
using Core.DTOs;
using Core.Interfaces.Services;
using Microsoft.EntityFrameworkCore;
using Persistence.DAL;
using Persistence.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Services
{
    public class FriendsService : IFriendsService
    {

        private readonly AppDbContext _context;
        public FriendsService(AppDbContext context)
        {
            _context = context;
        }

        public (int, List<FriendDTO>) GetFriends(FriendsPageFilter filter)
        {
            //TODO OPTIMIZE QUERY PLEASEEEEE
            //TODO  correct filter and check if data is correct

            var query = _context.Friendships.Where(f => f.FirstFriendId == filter.UserId).Include(f => f.SecondFriend)
                .ThenInclude(fr => fr.Library);

            int totalNumber = query.Count();

            var friends = query.Skip(filter.PageIndex * filter.PageSize).Take(filter.PageSize).Select(f => FriendCoreConverter.ToDTO(f.SecondFriend, true)).ToList();
            return (totalNumber, friends);
        }


        public List<FriendDTO> GetAllPossibleFriends(FriendsDialogFilter filter)
        {

            var allUsers = _context.Users.Include(u=>u.FirstFriends).ToList();

            var user = allUsers.FirstOrDefault(u => u.Id == filter.UserId);

            var friendsIds = user.FirstFriends.Select(f => f.SecondFriendId).ToList();

            var allPossibleFriends = allUsers.Where(u => u.Id != filter.UserId)
                .Select(u => FriendCoreConverter.ToDTO(u, friendsIds.Contains(u.Id))).ToList();

            return allPossibleFriends;
        }

        public void AddFriend(Guid userId, Guid friendId)
        {
            var friendship = new Friendship()
            {
                Id = Guid.NewGuid(),
                FirstFriendId = userId,
                SecondFriendId = friendId
            };
            _context.Friendships.Add(friendship);
            _context.SaveChanges();
            
        }
        public void RemoveFriend(Guid userId, Guid friendId)
        {
            var friendship = _context.Friendships.FirstOrDefault(f => f.FirstFriendId == userId && f.SecondFriendId == friendId);
            _context.Friendships.Remove(friendship);
            _context.SaveChanges();
        }
    }
}
