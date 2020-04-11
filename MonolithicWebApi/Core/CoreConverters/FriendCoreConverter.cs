using Common.DALConverters;
using Core.DTOs;
using Persistence.DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CoreConverters
{
    public class FriendCoreConverter
    {
        public static FriendDTO ToDTO(User user, bool isFriend)
        {
            if (user == null)
            {
                return null;
            }

            return new FriendDTO()
            {
                Id = user.Id,
                Name = user.UserName,
                Age = DateTime.Now.Year - user.YearOfBirth,
                Library = user.Library != null  ? LibraryCoreConverter.ToDTO( user.Library) : null,
                IsFriend = isFriend
            };
        }
    }
}
