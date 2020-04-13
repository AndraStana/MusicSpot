using Core.DTOs;
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
                UrlPicture = news.UrlPicture

    };
        }
    }
}
