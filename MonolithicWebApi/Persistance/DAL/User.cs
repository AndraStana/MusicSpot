using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Persistence.DAL
{
    public class User: IdentityUser<Guid>
    {

        public string Name { get; set; }
        public int YearOfBirth { get; set; }

        public Guid LibraryId { get; set; }
        public Library Library { get; set; }

        public List<Friendship> FirstFriends { get; set; }
        public List<Friendship> SecondFriends { get; set; }

    }
}
