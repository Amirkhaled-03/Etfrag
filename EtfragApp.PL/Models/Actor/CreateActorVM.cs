using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EtfragApp.PL.Models.Actor
{
    public class CreateActorVM
    {
        [Required]
        [DisplayName("First name")]
        public string FirstName { get; set; } = "";

        [Required]
        [DisplayName("Last name")]
        public string LastName { get; set; } = "";

        [Required(ErrorMessage = "Nationality is Required")]
        public string Nationality { get; set; } = "";

        public string? ImageURL { get; set; }

        [Required]
        public IFormFile ProfilePicture { get; set; }
    }
}
