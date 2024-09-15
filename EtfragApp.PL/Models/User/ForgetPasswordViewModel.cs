using System.ComponentModel.DataAnnotations;

namespace EtfragApp.PL.Models.User
{
    public class ForgetPasswordViewModel
    {
        [Required(ErrorMessage = "Email is Required")]
        [EmailAddress]
        public string Email { get; set; }
    }
}
