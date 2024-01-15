using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.AccountManager.AccountManagerContracts
{
    public interface IDeleteAccountManager
    {
        public Task<bool> DeleteAccount(string password);
    }
}
