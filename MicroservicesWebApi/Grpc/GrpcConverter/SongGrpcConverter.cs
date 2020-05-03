using Common.Models;
using MusicMicroservice;
using System;
using System.Collections.Generic;
using System.Text;

namespace Grpc.GrpcConverter
{
    public static class SongGrpcConverter
    {
        public static SongModel ToMessage(SongMessage song)
        {
            if (song == null)
            {
                return null;
            }

            return new SongModel()
            {
                Id = new Guid(song.Id),
                Name = song.Name,
                Artist = song.Artist,
                Album = song.Album,
                Year = song.Year,
                Url = song.Url,
                AlbumUrlPicture = song.AlbumUrlPicture,
                IsInLibrary = song.IsInLibrary,
        };
        }
    }

}
