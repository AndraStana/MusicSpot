using Core.DTOs;
using MonolithicWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MonolithicWebAPI.Converters
{
    public class FriendWebConverter
    {
        public static FriendModel ToModel(FriendDTO friendDTO)
        {
            if (friendDTO == null)
            {
                return null;
            }

            return new FriendModel()
            {
                Id = friendDTO.Id,
                Name = friendDTO.Name,
                Age = friendDTO.Age,
                LibraryName = friendDTO.Library!=null ? friendDTO.Library.Name: null,
                IsFriend = friendDTO.IsFriend
            };
        }
    }
}
