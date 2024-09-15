using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EtfragApp.DAL.Entities
{
    public class Category : BaseEntity
    {
        [Key]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Category Name is Required")]
        public string CategoryName { get; set; }

        public ICollection<MovieCategory> MovieCategories { get; set; }
        public ICollection<TVSeriesCategory> TVSeriesCategories { get; set; }



    }
}
