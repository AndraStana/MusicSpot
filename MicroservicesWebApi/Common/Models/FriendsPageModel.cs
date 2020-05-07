using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Models
{
    public class FriendsPageModel
    {
        public int TotalNumber { get; set; }
        public List<FriendModel> Friends { get; set; }
    }
}
