using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Common.Shared
{
    public class BasicPageFilter
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public Guid? UserId { get; set; }
    }
}

