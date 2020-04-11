using Common.Shared;
using Core.CoreConverters;
using Core.DTOs;
using Core.Interfaces.Services;
using Microsoft.EntityFrameworkCore;
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

            var friends = query.Skip(filter.PageIndex * filter.PageSize).Take(filter.PageSize).Select(f=> FriendCoreConverter.ToDTO(f.SecondFriend)).ToList();
            return (totalNumber, friends);
        }
    }
}
