using Entities.ApplicationUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.AccountManagerContracts
{
    public interface ILogin
    {
        public bool Login(PrimaryUser user);
    }
}
