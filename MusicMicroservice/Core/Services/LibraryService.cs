using Core.CoreConverters;
using Core.DTO;
using Core.Interfaces.Services;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using Persistence.DAL;
using System;
using System.Collections.Generic;

namespace Core.Services
{
    public class LibraryService:  ILibraryService
    {
        private readonly IMongoCollection<Library> libraryDbList;

        public LibraryService(IConfiguration config)
        {
            MongoClient client = new MongoClient(config["ConnectionStrings:DefaultConnection"]);

            IMongoDatabase database = client.GetDatabase("MusicSpotMusic");
            libraryDbList = database.GetCollection<Library>("Libraries");
        }


        public void AddLibrary(LibraryDTO libraryDTO)
        {
            var library = LibraryCoreConverter.ToDAL(libraryDTO);
            library.SongsIds = new List<Guid>();
            libraryDbList.InsertOne(library);
        }
    }
}
