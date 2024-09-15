using Microsoft.AspNetCore.Authentication;
using System.ComponentModel.DataAnnotations;

namespace EtfragApp.PL.Models.User
{
	public class LoginViewModel
	{
		[EmailAddress]
		[Required(ErrorMessage = "Email is required.")]
		public string? Email { get; set; }
		[Required(ErrorMessage = "Password is required.")]
		public string? Password { get; set; }
		public bool RememberMe { get; set; }

	}
}
