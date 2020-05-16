using Common.Models;
using Common.Shared;
using Grpc.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroservicesMusicWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ExploreController : ControllerBase
    {
        private readonly IArtistsService _artistsService;
        private readonly ILibraryService _libraryService;

        public ExploreController(IArtistsService artistsService, ILibraryService libraryService)
        {
            _artistsService = artistsService;
            _libraryService = libraryService;
        }


        [HttpPost]
        public List<ArtistModel> GetArtists([FromBody] ArtistsPageFilter filter)
        {
            var artists = _artistsService.GetArtistsAsync(filter);
            return artists.Result;
        }

    }
}