using System.ComponentModel.DataAnnotations;

namespace EtfragApp.PL.Models.User
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "name is requird")]
        public string? Name { get; set; }
        [Required(ErrorMessage ="Email address is Required")]
        [EmailAddress]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Password is Required.")]
        public string? Password { get; set; }

        [Required(ErrorMessage = "Confirmation Password is required.")]
        [Compare("Password", ErrorMessage = "Password and Confirmation Password must match.")]
        public string? ConfirmPassword { get; set; }
        [Required]
        public bool IsAgreed { get; set; }



    }
}
