﻿using System.ComponentModel.DataAnnotations;

namespace Demo.PL.ViewModels
{
	public class LoginViewModel
	{
        [Required(ErrorMessage = "Email is Reruired")]
        [EmailAddress(ErrorMessage = "Invaild Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is Reruired")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
       
        public bool RememberMe { get; set; }
    }
}
