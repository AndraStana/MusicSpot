using Common.Models;
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
        }
    }
