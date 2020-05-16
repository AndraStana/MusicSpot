using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Shared
{
    public class ArtistsPageFilter
    {
        public Guid LibraryId { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public string SearchText { get; set; }
    }
}
