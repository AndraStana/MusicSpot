using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.DAL
{
    public class Album
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid ArtistId { get; set; }
        public string UrlPicture { get; set; }

        public Artist Artist { get; set; }

        public List<Song> Songs { get; set; } 
    }
}
