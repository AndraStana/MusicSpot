using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MonolithicWebApi.Models
{
    public class AddRemoveFriendModel
    {
        public Guid UserId { get; set; }
        public Guid FriendId { get; set; }

    }
}
