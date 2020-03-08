﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.DAL
{
    public class User: IdentityUser
    {
        public string Name { get; set; }
        public int YearOfBirth { get; set; }

        public Guid LibraryId { get; set; }
        public Library Library { get; set; }
    }
}
