using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Models;
using Common.Shared;
using Grpc.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MicroservicesWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class RecommendedController : ControllerBase
    {
        private readonly ILibraryService _libraryService;

        public RecommendedController(ILibraryService libraryService)
        {
            _libraryService = libraryService;
        }

        public List<SongModel> GetRecommendedSongs(BasicPageFilter filter)
        {
            return _libraryService.GetRecommendedSongsAsync(filter).Result;
        }
    }
}