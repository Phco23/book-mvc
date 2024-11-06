using book_mvc.Models;
using book_mvc.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace book_mvc.Controllers
{
    public class SignInController : Controller
    {
		private UserManager<AppUserModel> _userManage;
		private SignInManager<AppUserModel> _signInManager;
		public SignInController(SignInManager<AppUserModel> signInManager, UserManager<AppUserModel> userManage)
		{
			_userManage = userManage;
			_signInManager = signInManager;
		}
		public IActionResult Index(string returnUrl = "/")
        {
			return View(new LoginViewModel { ReturnUrl = returnUrl });
		}

		[HttpPost]
		public async Task<IActionResult> Login(LoginViewModel loginVM)
		{
			if (ModelState.IsValid)
			{
				// Sign in using the provided credentials
				Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(loginVM.Username, loginVM.Password, false, false);
				if (result.Succeeded)
				{
					// Validate the return URL to prevent open redirect attacks

					return Redirect(loginVM.ReturnUrl ?? "/");


				}


				ModelState.AddModelError("", "Invalid username and password");
			}

			// Return the view with the login model if login failed
			return View(loginVM);
		}
        public async Task<IActionResult> Logout(string returnUrl = "/")
        {
            await _signInManager.SignOutAsync();
            return Redirect(returnUrl);
        }
    }
}
