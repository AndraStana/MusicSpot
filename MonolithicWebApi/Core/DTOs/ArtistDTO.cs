using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DTOs
{
    public class ArtistDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string UrlPicture { get; set; }

        public List<AlbumDTO> Albums { get; set; }

    }
}
