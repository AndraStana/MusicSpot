using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.DAL
{
    class Song
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }

    }
}
