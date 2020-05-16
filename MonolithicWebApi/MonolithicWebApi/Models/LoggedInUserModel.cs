using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MonolithicWebAPI.Models
{
    public class LoggedInUserModel
    {
        public Guid UserId { get; set; }
        public string Username { get; set; }
        public Guid LibraryId { get; set; }
    }
}
