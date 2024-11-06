using Microsoft.AspNetCore.Identity;

namespace book_mvc.Models
{
	public class AppUserModel : IdentityUser
	{
		public string Occupation { get; set; }
	}
}
