using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Models
{
    public class AddRemoveFriendModel
    {
        public Guid UserId { get; set; }
        public Guid FriendId { get; set; }
    }
}
