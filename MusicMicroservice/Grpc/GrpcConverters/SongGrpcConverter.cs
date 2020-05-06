using Core.DTO;
using MusicMicroservice;
using System;
using System.Collections.Generic;
using System.Text;

namespace Grpc.GrpcConverters
{
    public static class SongGrpcConverter
    {
        public static SongMessage ToMessage(SongDTO song)
        {
            if (song == null)
            {
                return null;
            }

            if(song.Artist == null)
            {
                var off = 3;
            }

            return new SongMessage()
            {
                Id = song.Id.ToString(),
               Name = song.Name,
                Artist = song.Artist,
                Album = song.Album,
                Year = song.Year,
                Url = song.Url,
                AlbumUrlPicture = song.AlbumUrlPicture,
                IsInLibrary = song.IsInLibrary,
            };
        }


        public static SongSimpleMessage ToSimpleMessage(SongSimpleDTO song)
        {
            if (song == null)
            {
                return null;
            }

            return new SongSimpleMessage()
            {
                Id = song.Id.ToString(),
                Name = song.Name,
                Url = song.Url,
                IsInLibrary = song.IsInLibrary,
            };
        }
    }
}
