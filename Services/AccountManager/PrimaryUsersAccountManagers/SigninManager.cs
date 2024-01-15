using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWork.IDbRepo;
using Entities.Enums;
using Entities.DTOs;
using Services.AccountManager.AccountManagerContracts;

namespace Services.AccountManager.PrimaryUsersAccountManagers
{
    public class SigninManager : ISigninManager
    {
        private readonly IRepo _repo;
        public SigninManager(IRepo repo)
        {
            _repo = repo;
        }

        public async Task SignIn(SignInDTO newUser)
        {
            if (newUser == null)
            {
                throw new ArgumentNullException();
            }
            await _repo.AddUser(newUser.ToPrimaryUser(Roles.PrimaryUser));
        }
    }
}
