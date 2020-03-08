using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.DAL
{
    public class Library
    {
        public Guid Id { get; set; }
        public string Name { get; set; }


        public List<LibrarySong> LibrarySong { get; set; }

    }
}
