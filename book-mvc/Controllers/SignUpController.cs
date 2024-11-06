using book_mvc.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace book_mvc.Controllers
{
    public class SignUpController : Controller
    {
		private UserManager<AppUserModel> _userManage;
		private SignInManager<AppUserModel> _signInManager;

		public SignUpController(SignInManager<AppUserModel> signInManager, UserManager<AppUserModel> userManage)
		{
			_userManage = userManage;
			_signInManager = signInManager;
		}
		public IActionResult Index()
        {
            return View();
        }

		[HttpPost]
		public async Task<IActionResult> Create(UserModel user)
		{
			if (ModelState.IsValid)
			{
				AppUserModel newUser = new AppUserModel
				{
					UserName = user.Username,
					Email = user.Email
				};
				IdentityResult result = await _userManage.CreateAsync(newUser, user.Password);
				if (result.Succeeded)
				{
					return Redirect("/signin");
				}
				foreach (IdentityError error in result.Errors)
				{
					ModelState.AddModelError("", error.Description);
				}
			}
			return View(user);
		}
	}
}
