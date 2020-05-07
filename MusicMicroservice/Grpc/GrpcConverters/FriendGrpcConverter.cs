using Core.DTO;
using MusicMicroservice;
using System;
using System.Collections.Generic;
using System.Text;

namespace Grpc.GrpcConverters
{
    public class FriendGrpcConverter
    {
        public static FriendMessage ToMessage(FriendDTO friend)
        {
            if (friend == null)
            {
                return null;
            }

            return new FriendMessage()
            {
                Id = friend.Id.ToString(),
                Name = friend.Name,
                Age = friend.Age,
                LibraryName = friend.LibraryName,
                IsFriend = friend.IsFriend,
            };
        }
    }
}
