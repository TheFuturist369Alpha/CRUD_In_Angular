using Entities.ApplicationUser;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.AccountManager.AccountManagerContracts
{
    public interface ILoginManager
    {
        public Task<bool> Login(LoginDTO user);
    }
}
