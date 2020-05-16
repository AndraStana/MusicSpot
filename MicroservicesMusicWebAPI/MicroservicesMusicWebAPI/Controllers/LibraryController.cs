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
    public class LibraryController : ControllerBase
    {
        private readonly ILibraryService _libraryService;

        public LibraryController(ILibraryService libraryService)
        {
            _libraryService = libraryService;
        }

        public void AddLibrary(LibraryAddModel model)
        {
            _libraryService.AddLibraryAsync(model);
            return;
        }

        [HttpPost]
        public LibraryPageModel GetLibrarySongs([FromBody] LibraryPageFilter filter)
        {

            return _libraryService.GetLibrarySongsAsync(filter).Result;

        }

        public List<PopularityRankingModel> GetPopularityRankings()
        {
            return _libraryService.GetPopularityRankingsAsync().Result;

        }

        [HttpPost]
        public void RemoveSongFromLibrary(AddRemoveSongModel model)
        {
            _libraryService.RemoveSongFromLibraryAsync(model.LibraryId, model.SongId);
        }

        [HttpPost]
        public void AddSongToLibrary(AddRemoveSongModel model)
        {
            _libraryService.AddSongToLibraryAsync(model.LibraryId, model.SongId);
        }

    }
}
