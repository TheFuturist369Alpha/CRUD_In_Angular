using Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Other
{
    public class UserToString
    {
        public string ModelId { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public bool Remain_SignedIn { get; set; }

        public Roles roles { get; set; }
    }
}
