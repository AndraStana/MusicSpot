using Common.Shared;
using Core.CoreConverters;
using Core.DTOs;
using Core.Interfaces.Services;
using Persistence.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Services
{
    public class NewsService: INewsService
    {
        private readonly AppDbContext _context;
        public NewsService(AppDbContext context)
        {
            _context = context;
        }

        public List<NewsDTO> GetNews(BasicPageFilter filter)
        {
            return _context.News.OrderByDescending(n => n.CreationDate)
                .Skip(filter.PageIndex*filter.PageSize).Take(filter.PageSize)
                .Select(n=> NewsCoreConverter.ToDTO(n)).ToList();
        }
    }
}
