using Core.DTOs;
using Persistence.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.CoreConverters
{
    public class ArtistCoreConverter
    {
        public static ArtistDTO ToShortDTO(Artist artist)
        {
            if (artist == null)
            {
                return null;
            }

            return new ArtistDTO()
            {
                Id = artist.Id,
                Name = artist.Name,
                UrlPicture = artist.UrlPicture,
            };
        }

        public static ArtistDTO ToLongDTO(Artist artist)
        {
            if (artist == null)
            {
                return null;
            }

            return new ArtistDTO()
            {
                Id = artist.Id,
                Name = artist.Name,
                UrlPicture = artist.UrlPicture,
                Albums = artist.Albums.Select(a => AlbumCoreConverter.ToLongDTO(a)).ToList()
            };
        }
    }
}
