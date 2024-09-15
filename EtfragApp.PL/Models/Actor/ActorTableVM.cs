using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EtfragApp.PL.Models.Actor
{
    public class ActorTableVM
    {
        public int Id { get; set; }
        [Required]
        [DisplayName("First name")]
        public string FirstName { get; set; } = "";

        [Required]
        [DisplayName("Last name")]
        public string LastName { get; set; } = "";

        [Required(ErrorMessage = "Nationality is Required")]
        public string Nationality { get; set; } = "";

        [Required]
        public string ImageURL { get; set; }

        public int TotalFilmsInSite { get; set; } = 0;
        public int TotalSeriesInSite { get; set; } = 0;

        public DateTime AddedAt { get; set; }
    }
}
