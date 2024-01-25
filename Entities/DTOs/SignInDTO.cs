using Entities.ApplicationUser;
using Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class SignInDTO
    {
        [BindNever]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "This field is required")]
        
        public string First_Name { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public string Last_Name { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [EmailAddress(ErrorMessage = "Email format not valid")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string PassWordHash { get; set; }
       
        public bool Remain_SignedIn { get; set; } = false;

        public PrimaryUser ToPrimaryUser(Roles role)
        {
            return new PrimaryUser()
            {
                Id = Id,
                First_Name = First_Name,
                Last_Name = Last_Name,
                Email = Email,
                PasswordHash = PassWordHash,
               
                roles = role,
                Remain_SignedIn = Remain_SignedIn

            };


        }
        public PrimaryUser ToPrimaryUser()
        {
            return new PrimaryUser()
            {
                Id = Id,
                First_Name = First_Name,
                Last_Name = Last_Name,
                Email = Email,
                PasswordHash = PassWordHash,
                


            };
        }
    }
}
