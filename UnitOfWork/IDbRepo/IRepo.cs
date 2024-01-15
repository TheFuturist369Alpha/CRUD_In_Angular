using Entities.ApplicationUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitOfWork.IDbRepo
{
    public interface IRepo
    {
        public Task AddUser(PrimaryUser primaryUser);
        public Task UpdateUser(PrimaryUser primaryUser);
        public Task<bool> DeleteUser(Guid? Id);
        public Task<List<PrimaryUser>> GetAllUsers();
        public Task<PrimaryUser> GetUserById(Guid Id);
        public Task<PrimaryUser> GetUserByEmail(string email);
    }
}
