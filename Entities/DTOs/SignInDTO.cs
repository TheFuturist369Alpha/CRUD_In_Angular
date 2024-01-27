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
        
        public Guid ModelId { get; set; }
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
        public string PasswordHash { get; set; }
       
        public bool Remain_SignedIn { get; set; }

        public PrimaryUser ToPrimaryUser(Roles role)
        {
            return new PrimaryUser()
            {
                Id = ModelId,
                First_Name = First_Name,
                Last_Name = Last_Name,
                Email = Email,
                PasswordHash = PasswordHash,
               
                roles = role,
                Remain_SignedIn = Remain_SignedIn

            };


        }
        public PrimaryUser ToPrimaryUser()
        {
            return new PrimaryUser()
            {
                Id = ModelId,
                First_Name = First_Name,
                Last_Name = Last_Name,
                Email = Email,
                PasswordHash = PasswordHash,
                Remain_SignedIn= Remain_SignedIn
                


            };
        }
    }
}
