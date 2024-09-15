using Azure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace EtfragApp.DAL.Entities
{
    public abstract class Media : BaseEntity
    {
        public int Id { get; set; }


        [Required(ErrorMessage = "Title is Required")]
        public string Title { get; set; } = "";

        [Required(ErrorMessage = "Description is Required")]
        public string Description { get; set; } = "";

        [Required(ErrorMessage = "Thumbnail Image is Required")]
        [Url(ErrorMessage = "Invalid URL format for Thumbnail Image")]
        public string ThumbnailImageUrl { get; set; }

        [Required(ErrorMessage = "Cover Image is Required")]
        [Url(ErrorMessage = "Invalid URL format for Cover Image")]
        public string CoverImageUrl { get; set; }

        [Required(ErrorMessage = "Release Date is Required")]
        public string ReleasYear { get; set; }

        [Required(ErrorMessage = "Quality is Required")]
        public string Quality { get; set; }

        [Required(ErrorMessage = "Age Rating is Required")]
        public int AgeRating { get; set; }

        [Required(ErrorMessage = "Country is Required")]
        public string CountryOfOrigin { get; set; }

        public bool IsFeatured { get; set; } = false;

        [Required(ErrorMessage = "Directory name is required")]
        public string DirectorName { get; set; }

        public bool IsLocked { get; set; }  = false;

    }
}



