using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.DAL
{
    public class PopularityRanking
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<Song> Songs { get; set; }
    }
}
