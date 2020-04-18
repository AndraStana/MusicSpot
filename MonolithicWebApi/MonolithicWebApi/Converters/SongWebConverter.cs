using Core.DTOs;
using MonolithicWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MonolithicWebApi.Converters
{
    public static class SongWebConverter
    {

        public static SongModel ToModel(SongDTO songDTO, bool isInLibrary)
        {
            if (songDTO == null)
            {
                return null;
            }

            return new SongModel()
            {
                Id = songDTO.Id,
                Name = songDTO.Name,
                Artist = songDTO.Artist.Name,
                Album = songDTO.Album.Name,
                Year = songDTO.Year,
                Url = songDTO.Url,
                AlbumUrlPicture =songDTO.Album.UrlPicture,
                IsInLibrary = isInLibrary
            };
        }
    }
}
