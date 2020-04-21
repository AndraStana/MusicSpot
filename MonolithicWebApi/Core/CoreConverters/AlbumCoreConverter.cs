using Core.DTOs;
using Persistence.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.CoreConverters
{
    public class AlbumCoreConverter
    {

        public static AlbumDTO ToLongDTO(Album album)
        {
            if (album == null)
            {
                return null;
            }

            return new AlbumDTO()
            {
                Id = album.Id,
                Name = album.Name,
                UrlPicture = album.UrlPicture,
                Songs = album.Songs.Select(s=> SongCoreConverter.ToShortDTO(s)).ToList()
            };
        }


        public static AlbumDTO ToShortDTO(Album album)
        {
            if (album == null)
            {
                return null;
            }

            return new AlbumDTO()
            {
                Id = album.Id,
                Name = album.Name,
                UrlPicture = album.UrlPicture
            };
        }
    }
}
