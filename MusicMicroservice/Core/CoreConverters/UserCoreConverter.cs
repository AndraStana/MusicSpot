using Core.DTO;
using Persistence.DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CoreConverters
{
    public static class UserCoreConverter
    {
        public static UserDTO ToDTO(User user)
        {
            if (user == null)
            {
                return null;
            }

            return new UserDTO()
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email,
                YearOfBirth = user.YearOfBirth,
                LibraryId = user.LibraryId
            };
        }

        public static User ToDAL(UserDTO user)
        {
            if (user == null)
            {
                return null;
            }

            return new User()
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email,
                YearOfBirth = user.YearOfBirth,
                LibraryId = user.LibraryId
            };
        }
    }
}
