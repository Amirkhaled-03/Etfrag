using System.ComponentModel.DataAnnotations;

namespace EtfragApp.PL.Models.User
{
	public class ResetPasswordViewModel
	{
		[Required]
		[StringLength(10, MinimumLength = 6, ErrorMessage = "Minimun Length is 6 Characters")]
		public string? Password { get; set; }

		[Required]
		[StringLength(10, MinimumLength = 6, ErrorMessage = "Minimun Length is 6 Characters")]
		[Compare(nameof(Password), ErrorMessage = "Password and Confirmation Password must match.")]
		public string? ConfirmPassword { get; set; }
		[EmailAddress]
		public string? Email { get; set; }
		public string? Token { get; set; }
	}
}
