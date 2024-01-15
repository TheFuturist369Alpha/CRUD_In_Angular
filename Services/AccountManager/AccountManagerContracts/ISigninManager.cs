using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWork.IDbRepo;
using Entities.DTOs;

namespace Services.AccountManager.AccountManagerContracts
{
    public interface ISigninManager
    {
        public Task SignIn(SignInDTO newUser);

    }
}
