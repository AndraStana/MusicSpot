using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.DAL
{
    public class LibrarySong
    {
        public Guid Id { get; set; }

        public Guid LibraryId { get; set; }
        public Library Library { get; set; }


        public Guid SongId {get;set;}
        public Song Song { get; set; }

    }
}
