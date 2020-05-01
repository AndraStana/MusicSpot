using Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Interfaces.Services
{
    public interface IUsersService
    {
        void AddUser(UserDTO userDTO);
    }
}
