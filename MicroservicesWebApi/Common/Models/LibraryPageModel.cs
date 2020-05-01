using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Models
{
    public class LibraryPageModel
    {
        public int TotalNumber { get; set; }
        public List<SongModel> Songs { get; set; }
    }
}
