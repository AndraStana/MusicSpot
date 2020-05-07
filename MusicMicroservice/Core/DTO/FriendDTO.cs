using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DTO
{
    public class FriendDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string LibraryName { get; set; }
        public bool IsFriend { get; set; }
    }
}
