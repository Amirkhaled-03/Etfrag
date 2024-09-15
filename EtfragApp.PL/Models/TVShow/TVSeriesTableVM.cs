using System.ComponentModel.DataAnnotations;

namespace EtfragApp.PL.Models.Media
{
    public class TVSeriesTableVM
    {
        [Required(ErrorMessage ="ID is required")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is Required")]
        public string Title { get; set; }


        [Required(ErrorMessage = "Added Date is Required")]
        public DateTime AddedAt { get; set; }


        [Required(ErrorMessage = "Duration is Required")]
        public int Duration { get; set; }


        [Required(ErrorMessage = "Age Rating is Required")]
        public int AgeRating { get; set; }


        [Required(ErrorMessage = "Country is Required")]
        public string CountryOfOrigin { get; set; }


        [Required(ErrorMessage = "Category is Required")]
        public string Category { get; set; }

        public bool IsFeatured { get; set; }



    }
}
