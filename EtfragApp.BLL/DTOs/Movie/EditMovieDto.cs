using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EtfragApp.BLL.DTOs.Movie
{
    public class EditMovieDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The Image is Required")]
        public IFormFile? ThumbnailImage { get; set; }

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

        [Required(ErrorMessage = "The Cover Image is Required")]
        public IFormFile? CoverImage { get; set; }

        [Required(ErrorMessage = "The Video is Required")]
        public IFormFile? MediaVideo { get; set; }

        [Required(ErrorMessage = "Director Name is Required")]
        public string DirectorName { get; set; }

    }
}
