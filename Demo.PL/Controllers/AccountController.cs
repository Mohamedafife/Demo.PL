using Demo.DAL.Entitys;
using Demo.PL.Helpers;
using Demo.PL.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Demo.PL.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplictionUser> _userManager;
        private readonly SignInManager<ApplictionUser> _signInManager;

        public AccountController(UserManager<ApplictionUser> userManager,SignInManager<ApplictionUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        #region Register
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel RegisterVM)
        {
            if (ModelState.IsValid)//Client side Validation
            {
                //Mapping
                var User = new ApplictionUser()
                {
                    UserName = RegisterVM.Email.Split('@')[0],
                    Email = RegisterVM.Email,
                    IsAgree = RegisterVM.IsAgree,
                };
                var Result = await _userManager.CreateAsync(User, RegisterVM.Password);
                if (Result.Succeeded)
                    return RedirectToAction(nameof(Login));
                foreach (var error in Result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(RegisterVM);
        }
        #endregion

        #region Login
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginVM)
        {
          if(ModelState.IsValid)
          {
                var User = await _userManager.FindByEmailAsync(loginVM.Email);
                if(User != null)
                {
                    bool flag = await _userManager.CheckPasswordAsync(User, loginVM.Password);
                    if (flag)
                    {
                        var Result = await _signInManager.PasswordSignInAsync(User, loginVM.Password, loginVM.RememberMe, false);
                        if (Result.Succeeded)
                            return RedirectToAction("Index", "Home");
                    }
                    ModelState.AddModelError("", "The Password is Not Correct");
                }
                ModelState.AddModelError("", "The Email is Not Correct");
          }

            return View(loginVM);
        }
        #endregion

        #region Signout
        public new async Task<IActionResult> SignOut()
        {
            await _signInManager.SignOutAsync();
           return RedirectToAction(nameof(Login));
        }
        #endregion
        #region Forget Password
        public IActionResult ForgetPassword()
        {
            return View();
        }
        #endregion
        #region Send Email
        [HttpPost]
        public async Task<IActionResult> SendEmail(ForgetPasswordViewModel forgetPasswordVM)
        {
            if (ModelState.IsValid)
            {
                var User = await _userManager.FindByEmailAsync(forgetPasswordVM.Email);
                if(User != null)
                {
                    var token = await _userManager.GeneratePasswordResetTokenAsync(User);  
                    var resetpasswordlink = Url.Action("ResetPassword","Account",new {Email=forgetPasswordVM.Email,Request.Scheme});
                    var email = new Email()
                    {
                        Subject = "Reset Your  Password",
                        To = forgetPasswordVM.Email,
                        Body = resetpasswordlink,
                    };
                    EmailSeeting.SendEmail(email);
                    return RedirectToAction(nameof(CheckYourInbox));
                }
                ModelState.AddModelError(string.Empty, "Email is Not Exiset");
            }
            return View(forgetPasswordVM);
        }
        #endregion
        #region CheckYourPassword
        public IActionResult CheckYourInbox()
        {
            return View();
        }
        #endregion
        #region ResetPassword
        public IActionResult ResetPassword(string Email , string Token)
        {
            TempData["Email"] = Email;
            TempData["Token"] = Token;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel resetPasswordVM)
        {
            if (ModelState.IsValid)
            {
               string Email = TempData["Email"] as string;
               string Token = TempData["Token"] as string;
               var User = await _userManager.FindByEmailAsync(Email);
               var Result = await _userManager.ResetPasswordAsync(User,Token,resetPasswordVM.NewPassword);
                if(Result.Succeeded)
                    return RedirectToAction(nameof(Login));
                foreach (var error in Result.Errors)
                    ModelState.AddModelError(string.Empty, error.Description);
            }
            return View(resetPasswordVM);
        }
        #endregion
    }
}
