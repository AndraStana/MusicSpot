using Core.DTO;
using Persistence.DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CoreConverters
{
    public class NewsCoreConverter
    {

        public static NewsDTO ToDTO(News news)
        {
            if (news == null)
            {
                return null;
            }

            return new NewsDTO()
            {
                Id = news.Id,
                Description = news.Description,
                UrlPicture = news.UrlPicture,
                Source = news.Source.Name
            };
        }


        public static News ToDAL(NewsDTO news)
        {
            if (news == null)
            {
                return null;
            }

            return new News()
            {
                Id = news.Id,
                Description = news.Description,
                CreationDate = news.CreationDate,
                UrlPicture = news.UrlPicture,
                Source = new Source()
                {
                    Id = Guid.NewGuid(),
                    Name = news.Source,
                }
        };
        }
    }
}