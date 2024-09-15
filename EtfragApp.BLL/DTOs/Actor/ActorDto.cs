using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EtfragApp.BLL.DTOs.Actor
{
    public class ActorDto
    {
        public int ActorId { get; set; }

        [Required]
        public string FirstName { get; set; } = "";

        [Required]
        public string LastName { get; set; } = "";

        [Required]
        [Url(ErrorMessage = "Invalid URL format for Profile Picture")]
        public string ProfilePictureUrl { get; set; } = "";

        [Required]
        public string Nationality { get; set; }

        public DateTime AddedAt { get; set; }   

    }
}
