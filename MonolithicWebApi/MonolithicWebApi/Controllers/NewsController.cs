using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Shared;
using Core.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MonolithicWebApi.Converters;
using MonolithicWebApi.Models;

namespace MonolithicWebApi.Controllers
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
            return _newsService.GetNews(filter).Select(n=>NewsWebConverter.ToModel(n)).ToList();
        }

    }
}