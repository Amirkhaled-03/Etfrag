using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EtfragApp.BLL.DTOs.Movie
{
    public class MovieDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is Required")]
        public string? Title { get; set; }

        [Required(ErrorMessage = "Description is Required")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Release Date is Required")]
        public string ReleasYear { get; set; }

        [Required(ErrorMessage = "Duration is Required")]
        public int Duration { get; set; }

        [Required(ErrorMessage = "Quality is Required")]
        public string Quality { get; set; }

        [Required(ErrorMessage = "Age Rating is Required")]
        public int AgeRating { get; set; }

        [Required(ErrorMessage = "Country is Required")]
        public string CountryOfOrigin { get; set; }

        [Required(ErrorMessage = "Director Name is Required")]
        public string DirectorName { get; set; }
        public bool IsFeatured { get; set; }

        //[Required(ErrorMessage = "Category is Required")]
        //public List<int>? CategoriesIDs { get; set; }

        //[Required(ErrorMessage = "Actor Name is Required")]
        //public List<int>? ActorIDs { get; set; }

        public DateTime AddedAt { get; set; }

        [Url(ErrorMessage = "Video URL format for Trailer")]
        public string? VideoURl { get; set; }

        [Url(ErrorMessage = "Invalid URL format for Thumbnail Image")]
        public string? ThumbnailImageUrl { get; set; }

        [Url(ErrorMessage = "Invalid URL format for Cover Image")]
        public string? CoverImageUrl { get; set; }
    }
}
