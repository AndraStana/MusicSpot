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
        public class NewsController : ControllerBase
        {
            private readonly INewsService _newsService;


            public NewsController(INewsService newsService)
            {
                _newsService = newsService;
            }

            public List<NewsModel> GetNews(BasicPageFilter filter)
            {
                return _newsService.GetNewsAsync(filter).Result;
            }

        }
    }
