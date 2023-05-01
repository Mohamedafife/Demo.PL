using System.ComponentModel.DataAnnotations;

namespace Demo.PL.ViewModels
{
	public class ResetPasswordViewModel
	{
        [Required(ErrorMessage = "NewPassword is Reruired")]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }
        [Required(ErrorMessage = "Comfirm Password is Reruired")]
        [Compare("Password", ErrorMessage = " ConfirmPassword dose not Match Password")]
        public string ConfirmPassword { get; set; }
    }
}
