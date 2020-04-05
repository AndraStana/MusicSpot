using Core.DTOs;
using Persistence.DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CoreConverters
{
    public class SongCoreConverter
    {
        public static SongDTO ToDTO(Song song)
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
                Album = AlbumCoreConverter.ToDTO(song.Album),
                Artist = ArtistCoreConverter.ToDTO(song.Album.Artist),
                Url = song.Url
            };
        }
    }
}
