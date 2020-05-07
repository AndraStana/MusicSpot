using Common.Models;
using Common.Shared;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Grpc.Interfaces
{
    public interface IFriendsService
    {
        Task<FriendsPageModel> GetFriendsAsync(FriendsPageFilter filter);
        Task<List<FriendModel>> GetAllPossibleFriendsAsync(Guid userId);
        Task AddFriendAsync(Guid userId, Guid friendId);
        Task RemoveFriendAsync(Guid userId, Guid friendId);
    }
}
