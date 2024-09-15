using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EtfragApp.BLL.DTOs.Actor
{
    public class EditActorDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = "";

        public string LastName { get; set; } = "";

        public string Nationality { get; set; } = "";

        public IFormFile ProfilePicture { get; set; }
    }
}
