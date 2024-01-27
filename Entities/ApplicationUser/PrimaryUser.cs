using Microsoft.AspNetCore.Identity;
using Entities.Enums;
using System.ComponentModel.DataAnnotations;
using Entities.Other;

namespace Entities.ApplicationUser
{
    public class PrimaryUser
    {
        [Key]
       public Guid Id { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set;}
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public bool Remain_SignedIn { get; set; }
        
        public Roles roles { get; set; }

        public UserToString ToString()
        {
            return new UserToString()
            {
                ModelId = Id.ToString(),
                First_Name = First_Name,
                Last_Name = Last_Name,
                Email = Email,
                PasswordHash = PasswordHash,
                Remain_SignedIn = Remain_SignedIn
            };
        }
        

    }
}