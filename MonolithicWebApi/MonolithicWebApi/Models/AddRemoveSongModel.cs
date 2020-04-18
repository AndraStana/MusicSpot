using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MonolithicWebApi.Models
{
    public class AddRemoveSongModel
    {
        public Guid LibraryId { get; set; }
        public Guid SongId { get; set; }
    }
}
