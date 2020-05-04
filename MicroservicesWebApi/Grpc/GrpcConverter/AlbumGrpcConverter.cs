using Common.Models;
using MusicMicroservice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Grpc.GrpcConverter
{
    public class AlbumGrpcConverter
    {

        public static AlbumModel ToModel(AlbumMessage album)
        {
            if (album == null)
            {
                return null;
            }

            return new AlbumModel()
            {
                Id = new Guid(album.Id),
                Name = album.Name,
                UrlPicture = album.UrlPicture,
                Songs = album.Songs.Select(a => SongGrpcConverter.ToSimpleModel(a)).ToList()
            };
        }
    }
}
