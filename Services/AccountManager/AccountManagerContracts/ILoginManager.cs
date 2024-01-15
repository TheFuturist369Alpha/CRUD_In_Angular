using Entities.ApplicationUser;
using Entities.DTOs;
using Entities.Other;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.AccountManager.AccountManagerContracts
{
    public interface ILoginManager
    {
        public Task<bool> Login(LoginEntity user);
    }
}
