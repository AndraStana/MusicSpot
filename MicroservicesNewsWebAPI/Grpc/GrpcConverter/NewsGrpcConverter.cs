using Common.Models;
using NewsMicroservice;
using System;
using System.Collections.Generic;
using System.Text;

namespace Grpc.GrpcConverter
{
    public static class NewsGrpcConverter
    {
        public static NewsModel ToMessage(NewsMessage news)
        {
            if (news == null)
            {
                return null;
            }

            return new NewsModel()
            {
                Id = new Guid(news.Id),
                Description = news.Description,
                UrlPicture = news.UrlPicture,
                Source = news.Source
            };
        }
    }
}