using Common.Shared;
using Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Interfaces.Services
{
    public interface INewsService
    {
        List<NewsDTO> GetNews(BasicPageFilter filter);
        long GetCount();

        void AddNewsList(List<NewsDTO> newsList);
    }
}
