﻿using System.ComponentModel.DataAnnotations;

namespace CreativeIndustries.API.DXS.AccountViewModels
{
    public class RegistrationViewModel
    {
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "emailRequired")]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "passwordRequired")]
        [StringLength(100, ErrorMessage = "passwordStringLength", MinimumLength = 8)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "confirmPasswordNotMatching")]
        public string ConfirmPassword { get; set; }

    }
}

