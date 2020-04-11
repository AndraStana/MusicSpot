using Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DTOs
{
    public class FriendDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public LibraryDTO Library { get;set; } 
    }
}
