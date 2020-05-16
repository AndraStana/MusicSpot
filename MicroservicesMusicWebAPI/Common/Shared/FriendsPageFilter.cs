using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Shared
{
    public class FriendsPageFilter
    {
        public Guid UserId { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }
}
