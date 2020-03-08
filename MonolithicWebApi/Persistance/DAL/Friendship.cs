using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.DAL
{
    public class Friendship
    {
        public Guid Id { get; set; }
        public Guid FirstFriendId { get; set; }
        public Guid SecondFriendId { get; set; }

        public User FirstFriend { get; set; }
        public User SecondFriend { get; set; }

    }
}
