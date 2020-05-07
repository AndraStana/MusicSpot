using Common.Shared;
using Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Interfaces.Services
{
    public interface IFriendsService
    {
        void AddFriend(Guid userId,Guid friendId);
        void RemoveFriend(Guid userId, Guid friendId);
        (int, List<FriendDTO>) GetFriends(FriendsPageFilter filter);
        List<FriendDTO> GetAllPossibleFriends(Guid userId);

    }
}
