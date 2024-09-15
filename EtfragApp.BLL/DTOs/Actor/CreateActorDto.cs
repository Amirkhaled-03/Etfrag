using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace EtfragApp.BLL.DTOs.Actor
{
    public class CreateActorDto
    {
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string Nationality { get; set; } = "";
        public IFormFile ProfilePicture { get; set; }
    }
}
