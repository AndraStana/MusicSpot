using Core.DTOs;
using Persistence.DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CoreConverters
{
    public class AlbumCoreConverter
    {
        public static AlbumDTO ToDTO(Album album)
        {
            if (album == null)
            {
                return null;
            }

            return new AlbumDTO()
            {
                Id = album.Id,
                Name = album.Name
            };
        }
    }
}
