using Core.DTOs;
using Persistence.DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CoreConverters
{
    public class ArtistCoreConverter
    {
        public static ArtistDTO ToDTO(Artist artist)
        {
            if (artist == null)
            {
                return null;
            }

            return new ArtistDTO()
            {
                Id = artist.Id,
                Name = artist.Name
            };
        }
    }
}
