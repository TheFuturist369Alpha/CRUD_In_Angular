using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWork.IDbRepo;
using Entities.ApplicationUser;
using Services.AccountManager.AccountManagerContracts;

namespace Services.AccountManager.PrimaryUsersAccountManagers
{
    public class UpdateManager : IUpdateAccountManager
    {
        private readonly IRepo _repo;

        public UpdateManager(IRepo repo)
        {
            _repo = repo;
        }

        public async Task<bool> UpdateUser(string password,SignInDTO replace)
        {
            if (password == null || replace==null) {
                return false;
                    }
            PrimaryUser user = await _repo.GetUserByProperty(password);
            if (user != null){
                    await _repo.UpdateUser(replace.ToPrimaryUser());
                return true;
            }
            return false;

        }
    }
}
