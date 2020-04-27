using Core.DTO;
using NewsMicroservice;
using System;
using System.Collections.Generic;
using System.Text;

namespace Grpc.GrpcConverters
{
    public static class NewsGrpcConverter
    {
        public static NewsMessage ToMessage(NewsDTO news)
        {
            if (news == null)
            {
                return null;
            }

            return new NewsMessage()
            {
                Id = news.Id.ToString(),
                Description = news.Description,
                UrlPicture = news.UrlPicture
            };
        }
    }
}
