using FluentValidation;
using FluentValidation.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using User_Domain;
using User_Infrastructure.User_Map;

namespace User_Infrastructure.User_Validation
{
   
    public class Validation_User : AbstractValidator<UserDto>
    {
        public Validation_User()
        {
            RuleFor(user => user.Name).NotEmpty().MaximumLength(20).MinimumLength(5).WithMessage("First name is required.");
            RuleFor(user => user.LName).NotEmpty().MaximumLength(20).MinimumLength(5).WithMessage("FullNameis required.");
            //-----------------------------------------
            RuleFor(user => user.Email)
     .NotEmpty().WithMessage("Email is required.")
     .EmailAddress(EmailValidationMode.Net4xRegex) // More thorough validation
     .WithMessage("Please enter a valid email address.").
     Must(BeAllowedEmailDomain).WithMessage("Invalid email domain."); 
            //-------------------------------------
            RuleFor(user => user.PasswordHash)
     .NotEmpty().WithMessage("Password is required.")
     .MinimumLength(8).WithMessage("Password must be at least 8 characters long.")
     .MaximumLength(30).WithMessage("Password cannot exceed 30 characters.")
    //.Matches(@"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[^\da-zA-Z])(?=.*\s)*$")
     .WithMessage("Password must contain at least one digit, one lowercase letter, one uppercase letter, and one special character.");
//--------------------------------------------------------------
          
           
        }
        private bool BeAllowedEmailDomain(string email)
        {
            string pattern = @"@(gmail\.com|yahoo\.com|example\.com)$";
            return Regex.IsMatch(email, pattern);
        }

    }
}
