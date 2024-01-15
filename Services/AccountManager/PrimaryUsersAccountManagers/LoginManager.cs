using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Entities.ApplicationUser;
using Entities.DTOs;
using Services.AccountManager.AccountManagerContracts;
using UnitOfWork;
using UnitOfWork.DbRepo;
using UnitOfWork.IDbRepo;

namespace Services.AccountManager.PrimaryUsersAccountManagers
{
    public class LoginManager : ILoginManager
    {
        private readonly IRepo _repo;
        public LoginManager(IRepo repo)
        {
            _repo = repo;
        }
        public async Task<bool> Login(LoginDTO user)
        {
            if (user == null)
            {
                return false;
            }

            PrimaryUser U1 = await _repo.GetUserByProperty(user.Email);
            if (U1 == null)
            {
                return false;
            }
            return U1.PasswordHash == user.Password;

        }

    }
}
