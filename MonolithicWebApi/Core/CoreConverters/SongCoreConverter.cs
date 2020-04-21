using Core.DTOs;
using Persistence.DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CoreConverters
{
    public class SongCoreConverter
    {
        public static SongDTO ToLongDTO(Song song)
        {
            if (song == null)
            {
                return null;
            }

            return new SongDTO()
            {
                Id = song.Id,
                Name = song.Name,
                Year = song.Year,
                Album = AlbumCoreConverter.ToShortDTO(song.Album),
                Artist = ArtistCoreConverter.ToShortDTO(song.Album.Artist),
                Url = song.Url
            };
        }

        public static SongDTO ToShortDTO(Song song)
        {
            if (song == null)
            {
                return null;
            }

            return new SongDTO()
            {
                Id = song.Id,
                Name = song.Name,
                Year = song.Year,
                Url = song.Url
            };
        }
    }
}
