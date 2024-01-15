﻿using Entities.ApplicationUser;
using Services.AccountManager.AccountManagerContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWork.IDbRepo;

namespace Services.AccountManager.PrimaryUsersAccountManagers
{
    public class DeleteAccountManager:IDeleteAccountManager
    {
        private readonly IRepo _repo;
        public DeleteAccountManager(IRepo repo)
        {
            _repo = repo;
        }

        public async Task<bool> DeleteAccount(string password)
        {
            if (password == null)
            {
                return false;
            }
            PrimaryUser user = await _repo.GetUserByProperty(password);
            if (user != null) 
            {
                await _repo.DeleteUser(user.Id); return true;
            }
            return false;
        }
    }
}
