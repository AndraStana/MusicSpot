using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MonolithicWebApi.Models
{
    public class LibraryPageModel
    {
        public int TotalNumber { get; set; }
        public List<SongModel> Songs {get;set;}
    }
}
