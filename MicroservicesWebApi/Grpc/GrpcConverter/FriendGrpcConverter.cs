using Common.Models;
using MusicMicroservice;
using System;
using System.Collections.Generic;
using System.Text;

namespace Grpc.GrpcConverter
{
    public class FriendGrpcConverter
    {
        public static FriendModel ToMessage(FriendMessage friend)
        {
            if (friend == null)
            {
                return null;
            }

            return new FriendModel()
            {
                Id = new Guid(friend.Id),
                Name = friend.Name,
                Age = friend.Age,
                LibraryName = friend.LibraryName,
                IsFriend = friend.IsFriend,
            };
        }
    }
}
