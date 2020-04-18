using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Interfaces.Services;
using Common.Shared;
using Microsoft.AspNetCore.Mvc;
using MonolithicWebApi.Converters;
using MonolithicWebApi.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MonolithicWebApi.Controllers
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
            return _libraryService.GetRecommendedSongs(filter).Select(n => SongWebConverter.ToModel(n, false)).ToList();
        }
    }
}