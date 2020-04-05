using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DTOs
{
    public class SongDTO
    {
        public Guid Id {get;set;}
        public string Name { get; set; }
        public int Year { get; set; }
        public AlbumDTO Album { get; set; }
        public ArtistDTO Artist { get; set; }
        public string Url { get; set; }

    }
}
