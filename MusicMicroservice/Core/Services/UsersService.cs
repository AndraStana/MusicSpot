using Core.CoreConverters;
using Core.DTO;
using Core.Interfaces.Services;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using Persistence.DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Services
{
    public class UsersService : IUsersService
    {
        private readonly IMongoCollection<User> userDbList;

        public UsersService(IConfiguration config)
        {
            MongoClient client = new MongoClient(config["ConnectionStrings:DefaultConnection"]);

            IMongoDatabase database = client.GetDatabase("MusicSpotMusic");
            userDbList = database.GetCollection<User>("Users");
        }

        public void AddUser(UserDTO userDTO)
        {
            var user = UserCoreConverter.ToDAL(userDTO);
            userDbList.InsertOne(user);
        }
    }
}
