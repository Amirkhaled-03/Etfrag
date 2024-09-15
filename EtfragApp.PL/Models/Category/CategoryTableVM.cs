using System.ComponentModel.DataAnnotations;

namespace EtfragApp.PL.Models.Category
{
    public class CategoryTableVM
    {
        [Required(ErrorMessage = "Category Id is Required")]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Category Name is Required")]
        public string CategoryName { get; set; }

        [Required(ErrorMessage = "Total Films is Required")]
        public int TotalSeriesInThisCategory { get; set; } = 0;

        [Required(ErrorMessage = "Total Series is Required")]
        public int TotalFilmsInThisCategory { get; set; } = 0;

        [Required(ErrorMessage = "Added Date is Required")]
        public DateTime AddedAt { get; set; }
    }
}
