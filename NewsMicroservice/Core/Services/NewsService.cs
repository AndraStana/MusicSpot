using MongoDB.Driver;
using Persistence.DAL;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using Core.Interfaces.Services;
using Core.DTO;
using Common.Shared;
using System.Linq;
using Core.CoreConverters;

namespace Core.Services
{
    public class NewsService: INewsService
    {
        private readonly IMongoCollection<News> newsDbList;

        public NewsService(IConfiguration config)
        {
            MongoClient client = new MongoClient(config["ConnectionStrings:DefaultConnection"]);

            IMongoDatabase database = client.GetDatabase("MusicSpotNews");
            newsDbList = database.GetCollection<News>("News");
        }

        public void AddNewsList(List<NewsDTO> newsList)
        {
            var newsDal = newsList.Select(n =>
            {
                n.Id = Guid.NewGuid();

                return NewsCoreConverter.ToDAL(n);
            }) ;

            newsDbList.InsertMany(newsDal);
        }

        public List<NewsDTO> GetNews(BasicPageFilter filter)
        {
            var news = newsDbList.Find(bson => true).SortByDescending(bson => bson.CreationDate)
                .Skip(filter.PageIndex * filter.PageSize).Limit(filter.PageSize)
                .ToList();
            return news.Select(n => NewsCoreConverter.ToDTO(n)).ToList();
        }

        public long GetCount()
        {
            return newsDbList.Find(bsn => true).Count();
        }

    }
}