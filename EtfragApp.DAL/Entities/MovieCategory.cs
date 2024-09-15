using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EtfragApp.DAL.Entities
{
    public class MovieCategory : BaseEntity
    {

        public int MediaId { get; set; }
        public Movie Movie { get; set; } 

        public int CategoryId { get; set; }
        public Category Category { get; set; } 


    }
}
