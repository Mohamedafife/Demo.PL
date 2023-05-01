using System.ComponentModel.DataAnnotations;

using System;
namespace Demo.PL.ViewModels
{
	public class RegisterViewModel
	{
		[Required(ErrorMessage ="Email is Reruired")]
		[EmailAddress(ErrorMessage ="Invaild Email")]
		public string Email { get; set; }
        [Required(ErrorMessage = "Password is Reruired")]
		[DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Comfirm Password is Reruired")]
		[Compare("Password",ErrorMessage = "Comfirm Password dose not Match Password")]
        public string ComfirmPassword { get; set; }
		public bool IsAgree { get; set; }
	}
}