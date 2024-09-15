using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EtfragApp.DAL.Entities
{
    public class Movie : Media
    {
        public int Duration { get; set; }

        [Url(ErrorMessage = "Video URL format is required")]
        public string VideoURl { get; set; }


        public ICollection<MovieCategory> MovieCategories { get; set; }
        public ICollection<MovieActor> MovieActors { get; set; }


    }
}
