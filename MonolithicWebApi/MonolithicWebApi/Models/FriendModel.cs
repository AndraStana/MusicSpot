using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MonolithicWebAPI.Models
{
    public class FriendModel
    {

        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string LibraryName { get; set; }
        public bool IsFriend { get; set; }

    }
}
