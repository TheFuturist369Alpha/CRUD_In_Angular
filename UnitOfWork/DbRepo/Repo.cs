using Entities.ApplicationUser;
using GenDataBase;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWork.IDbRepo;


namespace UnitOfWork.DbRepo
{
    public class Repo : IRepo
    {
        private readonly GenDbContext _context;


        public Repo(GenDbContext context)
        {
            _context = context;
        }


        public async Task AddUser(PrimaryUser primaryUser)
        {
            if (primaryUser == null)
            {
                throw new ArgumentNullException();
            }
            
            PrimaryUser? user= await _context.Users.FirstOrDefaultAsync(arg=>arg.Email== primaryUser.Email);
            if (primaryUser.Email == user?.Email)
            {
                throw new Exception("Email already exists");
            }

            await _context.Users.AddAsync(primaryUser);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteUser(Guid? Id)
        {
            if (Id == null)
            {
                throw new ArgumentNullException();  
            }
            PrimaryUser user = await _context.Users.FindAsync(Id);
            if (user==null) {

                return false;
            
            }
            _context.Users.Remove(user);
           await _context.SaveChangesAsync();
            return true;


        }

        public async Task<List<PrimaryUser>?> GetAllUsers()
        {
            if(_context.Users==null || _context.Users.ToList().Count == 0)
            {
                return new List<PrimaryUser>();
            }
            return await _context.Users.ToListAsync();
        }

        public async Task<PrimaryUser> GetUserByEmail(string email)
        {
            if (email != null)
            {
                return await _context.Users.FindAsync(email);
            }
            throw new ArgumentNullException();
        }

        public async Task UpdateUser(PrimaryUser primaryUser)
        {
          PrimaryUser PUser= await _context.Users.FindAsync(primaryUser.Id);
            if (PUser==null)
            {
                throw new ArgumentException("User does not exist");
            }
            PUser.Email = primaryUser.Email;
            PUser.First_Name=primaryUser.First_Name;
            PUser.Last_Name=primaryUser.Last_Name;
            PUser.PhoneNumber = primaryUser.PhoneNumber;
            PUser.PasswordHash = primaryUser.PasswordHash;
            await _context.SaveChangesAsync();
        }
    }
}
