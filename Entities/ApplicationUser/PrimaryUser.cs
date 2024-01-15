using Microsoft.AspNetCore.Identity;
using Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace Entities.ApplicationUser
{
    public class PrimaryUser : IdentityUser<Guid>
    {
        [Key]
       public Guid Id { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set;}
        public Roles roles { get; set; }
        

    }
}