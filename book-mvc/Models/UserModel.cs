using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace book_mvc.Models
{
	public class UserModel
	{
		[Key]
		public int Id { get; set; }
		[Required(ErrorMessage = "Input username")]
		public string Username { get; set; }
		[Required(ErrorMessage = "Input email"), EmailAddress]
		public string Email { get; set; }
		[DataType(DataType.Password), Required(ErrorMessage = "Input password")]
		public string Password { get; set; }
        [NotMapped]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        public string ConfirmPassword { get; set; }
    }
}
