using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Models
{
    public class AddRemoveSongModel
    {
        public Guid LibraryId { get; set; }
        public Guid SongId { get; set; }
    }
}
