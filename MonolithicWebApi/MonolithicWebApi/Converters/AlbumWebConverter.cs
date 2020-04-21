using Core.DTOs;
using MonolithicWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MonolithicWebApi.Converters
{
    public class AlbumWebConverter
    {
        public static AlbumModel ToModel(AlbumDTO album)
        {
            if (album == null)
            {
                return null;
            }

            return new AlbumModel()
            {
                Id = album.Id,
                Name = album.Name,
                UrlPicture = album.UrlPicture,
                Songs = album.Songs.Select(s => SongWebConverter.ToSimpleModel(s)).ToList()
            };
        }
    }
}
