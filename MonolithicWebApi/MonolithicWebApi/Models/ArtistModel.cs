using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MonolithicWebAPI.Models
{
    public class ArtistModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string UrlPicture { get; set; }

        public List<AlbumModel> Albums { get; set; }
    }
}
