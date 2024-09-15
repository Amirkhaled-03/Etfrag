using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EtfragApp.BLL.DTOs.TVSeries
{
    public class EditTVSeriesDto
    {

        [Required(ErrorMessage = "The Image is Required")]
        public IFormFile? ThumbnailImage { get; set; }

        [Required(ErrorMessage = "Title is Required")]
        public string? Title { get; set; }

        [Required(ErrorMessage = "Description is Required")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Release Date is Required")]
        public string ReleasYear { get; set; }

        [Required(ErrorMessage = "Quality is Required")]
        public string Quality { get; set; }

        [Required(ErrorMessage = "Age Rating is Required")]
        public int AgeRating { get; set; }

        [Required(ErrorMessage = "Country is Required")]
        public string CountryOfOrigin { get; set; }

        [Required(ErrorMessage = "The Cover Image is Required")]
        public IFormFile? CoverImage { get; set; }

        public string MediaType { get; set; } = "TV Series";

        [Required(ErrorMessage = "Director Name is Required")]
        public string DirectorName { get; set; }

        [Required(ErrorMessage = "Category is Required")]
        public List<int>? CategoriesIDs { get; set; }

        [Required(ErrorMessage = "Actor Name is Required")]
        public List<int>? ActorIDs { get; set; }

        [Url(ErrorMessage = "Video URL format not valid")]
        public string? VideoURl { get; set; }

        [Url(ErrorMessage = "Invalid URL format for Thumbnail Image")]
        public string? ThumbnailImageUrl { get; set; }

        [Url(ErrorMessage = "Invalid URL format for Cover Image")]
        public string? CoverImageUrl { get; set; }

        public List<string> Episodes { get; set; } = new List<string>();
        // public List<IFormFile> Episodes { get; set; } = new List<IFormFile>();

    }
}
