using Microsoft.AspNetCore.Identity;
using Entities.Enums;
using System.ComponentModel.DataAnnotations;

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
        

    }
}