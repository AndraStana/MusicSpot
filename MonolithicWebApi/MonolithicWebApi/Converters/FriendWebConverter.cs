using Core.DTOs;
using MonolithicWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MonolithicWebApi.Converters
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
                LibraryName = friendDTO.Library.Name
            };
        }
    }
}
