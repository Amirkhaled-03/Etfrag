using System.ComponentModel.DataAnnotations;

namespace EtfragApp.PL.Models.Category
{
    public class CategoryVM
    {
        [Required(ErrorMessage = "Category Name is Required")]
        public string CategoryName { get; set; }
    }
}
