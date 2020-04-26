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

        //public List<News> GetAll()
        //{
        //    return newsDbList.Find(news => true).ToList();
        //}

        //public News Get(Guid id)
        //{
        //    return newsDbList.Find(car => car.Id == id).FirstOrDefault();
        //}

        //public News Add(News news)
        //{
        //    news.Id = Guid.NewGuid();
        //    newsDbList.InsertOne(news);
        //    return news;
        //}

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

        //public void Update(string id, Car carIn)
        //{
        //    cars.ReplaceOne(car => car.Id == id, carIn);
        //}

        //public void Remove(Car carIn)
        //{
        //    cars.DeleteOne(car => car.Id == carIn.Id);
        //}

        //public void Remove(string id)
        //{
        //    cars.DeleteOne(car => car.Id == id);
        //}
    }
}