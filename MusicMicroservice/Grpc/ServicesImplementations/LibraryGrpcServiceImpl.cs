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
    public class LibraryGrpcServiceImpl : LibraryGrpcService.LibraryGrpcServiceBase
    {
        private ILibraryService _libraryService { get; set; }

        public LibraryGrpcServiceImpl(ILibraryService libraryService)
        {
            _libraryService = libraryService;
        }

        public override Task<AddLibraryResponse> AddLibrary(AddLibraryRequest request, ServerCallContext context)
        {

            var library = new LibraryDTO()
            {
                Id = Guid.Parse(request.Id),
                Name = request.Name
            };

            _libraryService.AddLibrary(library);

            var response = new AddLibraryResponse();
            return Task.FromResult(response);
        }
    }
}
