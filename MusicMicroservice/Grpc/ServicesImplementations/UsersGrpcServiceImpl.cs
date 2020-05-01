using Core.DTO;
using Core.Interfaces.Services;
using Grpc.Core;
using MusicMicroservice;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Grpc.ServicesImplementations
{
    public class UsersGrpcServiceImpl : UsersGrpcService.UsersGrpcServiceBase
    {
        private IUsersService _usersService { get; set; }

        public UsersGrpcServiceImpl(IUsersService usersService)
        {
            _usersService = usersService;
        }

        public override Task<AddUserResponse> AddUser(AddUserRequest request, ServerCallContext context)
        {
            var user = new UserDTO()
            {
                Id = Guid.Parse(request.Id),
                Username = request.Username,
                Email = request.Email,
                YearOfBirth = request.YearOfBirth,
                LibraryId = Guid.Parse(request.LibraryId)
            };

            _usersService.AddUser(user);

            var response = new AddUserResponse();
            return Task.FromResult(response);
        }
    }
}
