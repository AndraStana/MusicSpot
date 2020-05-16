using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MonolithicWebAPI.Models
{
    public class RegisterAccountModel: LoginAccountModel
    {
        public string Username { get; set; }
        public int YearOfBirth { get; set; }
    }
}
