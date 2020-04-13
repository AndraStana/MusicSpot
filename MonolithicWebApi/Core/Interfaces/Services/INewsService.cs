using Common.Shared;
using Core.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Interfaces.Services
{
    public interface INewsService
    {
        List<NewsDTO> GetNews(NewsPageFilter filter);
    }
}
