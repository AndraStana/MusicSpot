using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Models
{
    public class AlbumModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string UrlPicture { get; set; }
        public List<SongSimpleModel> Songs { get; set; }
    }
}
