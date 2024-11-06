using System.ComponentModel.DataAnnotations;

namespace book_mvc.Models.ViewModels
{
	public class LoginViewModel
	{
		[Key]
		public int Id { get; set; }
		[Required(ErrorMessage = "Input username")]
		public string Username { get; set; }
		[DataType(DataType.Password), Required(ErrorMessage = "Input password")]
		public string Password { get; set; }
		public string ReturnUrl { get; set; }
	}
}
