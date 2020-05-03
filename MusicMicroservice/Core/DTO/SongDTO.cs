using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DTO
{
    public class SongDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Artist { get; set; }
        public string Album { get; set; }
        public int Year { get; set; }
        public string Url { get; set; }
        public string AlbumUrlPicture { get; set; }
        public bool IsInLibrary { get; set; }
    }
}
