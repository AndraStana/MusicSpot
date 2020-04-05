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

        [HttpGet]
        public int GetSongsNumber(Guid userId)
        {
            return _libraryService.GetSongsNumber(userId);
        }

        [HttpPost]

        public List<SongModel> GetLibrarySongs([FromBody] LibraryPageFilter filter)
        {
            return _libraryService.GetLibrarySongs(filter)
                .Select(s => SongWebConverter.ToModel(s)).ToList();
        }
    }
}