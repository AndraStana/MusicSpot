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

            //return _libraryService.GetLibrarySongs(filter);



            //var (totaNumber, songs) = _libraryService.GetLibrarySongs(filter);

            //return new LibraryPageModel()
            //{
            //    Songs = songs.Select(s => SongWebConverter.ToModel(s, true)).ToList(),
            //    TotalNumber = totaNumber
            //};


            return null;
        }

        //public List<NewsModel> GetNews(BasicPageFilter filter)
        //{
        //    return _newsService.GetNewsAsync(filter).Result;
        //}
    }
    }
