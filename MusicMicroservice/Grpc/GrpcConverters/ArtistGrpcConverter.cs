using Core.DTO;
using MusicMicroservice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Grpc.GrpcConverters
{
    public static class ArtistGrpcConverter
    {
        public static ArtistMessage ToMessage(ArtistDTO artist)
        {
            if (artist == null)
            {
                return null;
            }

            var art = new ArtistMessage()
            {
                Id = artist.Id.ToString(),
                Name = artist.Name,
                UrlPicture = artist.UrlPicture
            };

            art.Albums.AddRange(artist.Albums.Select(a => AlbumGrpcConverter.ToMessage(a)).ToList());

            return art;
        }


    }
}
