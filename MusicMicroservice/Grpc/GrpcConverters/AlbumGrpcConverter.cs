using Core.DTO;
using MusicMicroservice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Grpc.GrpcConverters
{
    public static class AlbumGrpcConverter
    {
    
        public static AlbumMessage ToMessage(AlbumDTO album)
        {
            if (album == null)
            {
                return null;
            }

            var alb = new AlbumMessage()
            {
                Id = album.Id.ToString(),
                Name = album.Name,
                UrlPicture = album.UrlPicture,
            };

            alb.Songs.AddRange(album.Songs.Select(s => SongGrpcConverter.ToSimpleMessage(s)).ToList());

            return alb;
        }
    }
}
