using Core.DTOs;
using MonolithicWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MonolithicWebAPI.Converters
{
    public class ArtistWebConverter
    {
        public static ArtistModel ToModel(ArtistDTO artist)
        {
            if (artist == null)
            {
                return null;
            }

            return new ArtistModel()
            {
                Id = artist.Id,
                Name = artist.Name,
                UrlPicture = artist.UrlPicture,
                Albums = artist.Albums.Select(a => AlbumWebConverter.ToModel(a)).ToList()
            };
        }
    }
}
