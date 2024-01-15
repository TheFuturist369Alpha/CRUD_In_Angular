using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.AccountManager.AccountManagerContracts
{
    public interface IUpdateAccountManager
    {
        public Task<bool> UpdateUser(string password, SignInDTO replace);
    }
}
