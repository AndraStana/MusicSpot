using Common.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Shared
{
    public class LibraryPageFilter
    {
        public Guid UserId { get; set; }
        public GenreEnum? Genre { get; set; }
        public DecadeEnum? Decade { get; set; }
        public Guid? PopularityRankingId {get;set;}
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }
}
