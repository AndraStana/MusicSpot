using Common.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Grpc.Interfaces
{
    public interface IUsersService
    {
        Task AddUserAsync(UserAddModel library);
    }
}
