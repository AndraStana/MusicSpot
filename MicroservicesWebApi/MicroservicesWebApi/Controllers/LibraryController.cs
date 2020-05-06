using Common.Models;
using Common.Shared;
using Grpc.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroservicesWebApi.Controllers
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



            //var (totaNumber, songs) = _libraryService.GetLibrarySongs(filter);

            //return new LibraryPageModel()
            //{
            //    Songs = songs.Select(s => SongWebConverter.ToModel(s, true)).ToList(),
            //    TotalNumber = totaNumber
            //};


            return null;
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
