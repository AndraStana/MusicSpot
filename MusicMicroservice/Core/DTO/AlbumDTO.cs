using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DTO
{
    public class AlbumDTO
    {
        public Guid Id { get; set; }
    public string Name { get; set; }
    public string UrlPicture { get; set; }
    public List<SongSimpleDTO> Songs { get; set; }
}
}
