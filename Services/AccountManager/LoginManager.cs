using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Entities.ApplicationUser;
using Services.AccountManagerContracts;
using UnitOfWork;

namespace Services.AccountManager
{
    public class LoginManager : ILogin
    {
        public bool Login(PrimaryUser user)
        {
            if (user == null)
            {
                return false;
            }
              
            //TODO: Make Login DTO (email and password fields)


        }

    }
}
