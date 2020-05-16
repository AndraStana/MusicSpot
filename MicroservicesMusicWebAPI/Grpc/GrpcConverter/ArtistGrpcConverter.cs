using Common.Models;
using MusicMicroservice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Grpc.GrpcConverter
{
    public class ArtistGrpcConverter
    {
        public static ArtistModel ToModel(ArtistMessage artist)
        {
            if (artist == null)
            {
                return null;
            }

            return new ArtistModel()
            {
                Id = new Guid(artist.Id),
                Name = artist.Name,
                UrlPicture = artist.UrlPicture,
                Albums = artist.Albums.Select(a => AlbumGrpcConverter.ToModel(a)).ToList()
            };
        }

    }
}
