using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MonolithicWebApi.Models
{
    public class FriendsPageModel
    {
        public int TotalNumber { get; set; }
        public List<FriendModel> Friends { get; set; }
    }
}
