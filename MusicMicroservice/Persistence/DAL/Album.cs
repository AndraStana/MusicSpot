using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.DAL
{
    public class Album
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string UrlPicture { get; set; }
        public List<Guid> SongsIds { get; set; }
    }
}
