using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DTO
{
    public class UserDTO
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public int YearOfBirth { get; set; }
        public Guid LibraryId { get; set; }
    }
}
