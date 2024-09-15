using EtfragApp.BLL.DTOs.Episode;

using System.ComponentModel.DataAnnotations;


namespace EtfragApp.BLL.DTOs.TVSeries
{
    public class TVSeriesDto
    {
        [Required(ErrorMessage = "ID is required")]
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

        [Required(ErrorMessage = "Director Name is Required")]
        public string DirectorName { get; set; }
        public string? Description { get; set; }

        [Required(ErrorMessage = "Release Date is Required")]
        public string ReleasYear { get; set; }

        [Required(ErrorMessage = "Quality is Required")]
        public string Quality { get; set; }

        [Url(ErrorMessage = "Invalid URL format for Thumbnail Image")]
        public string? ThumbnailImageUrl { get; set; }

        [Url(ErrorMessage = "Invalid URL format for Cover Image")]
        public string? CoverImageUrl { get; set; }

        [Required(ErrorMessage = "Category is Required")]
        public List<string> Categories { get; set; } = new List<string>();
        public bool IsFeatured { get; set; }

        //public List<string> Episodes { get; set; } = new List<string>();

        public List<EpisodeDto> Episodes { get; set; } = new List<EpisodeDto>();
    }
}
