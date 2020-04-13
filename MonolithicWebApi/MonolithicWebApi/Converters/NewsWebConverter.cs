using Core.DTOs;
using MonolithicWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MonolithicWebApi.Converters
{
    public class NewsWebConverter
    {
        public static NewsModel ToModel(NewsDTO news)
        {
            if (news == null)
            {
                return null;
            }

            return new NewsModel()
            {
                Id = news.Id,
                Description = news.Description,
                UrlPicture = news.UrlPicture

            };
        }
    }
}
