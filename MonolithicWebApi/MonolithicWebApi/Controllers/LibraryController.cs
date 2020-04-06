using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Common.Interfaces.Services;
using Common.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MonolithicWebApi.Converters;
using MonolithicWebApi.Models;
using Persistence.DAL;

namespace MonolithicWebApi.Controllers
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


        [HttpPost]

        public LibraryPageModel GetLibrarySongs([FromBody] LibraryPageFilter filter)
        {
            var (totaNumber, songs) = _libraryService.GetLibrarySongs(filter);

            return new LibraryPageModel()
            {
                Songs = songs.Select(s => SongWebConverter.ToModel(s)).ToList(),
                TotalNumber = totaNumber
            };
        }

        public List<PopularityRankingModel> GetPopularityRankings()
        {
            return _libraryService.GetPopularityRankings()
                .Select(p => PopularityRankingWebConverter.ToModel(p)).ToList();

        }
    }
}