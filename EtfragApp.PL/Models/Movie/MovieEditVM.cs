using System.ComponentModel.DataAnnotations;

namespace EtfragApp.PL.Models.Movie
{
	public class MovieEditVM
	{
		public IFormFile? ThumbnailImage { get; set; }

		public IFormFile? CoverImage { get; set; }

		public IFormFile? MediaVideo { get; set; }

		public string Title { get; set; }

		public string? Description { get; set; }

		public int Duration { get; set; }

		public string Quality { get; set; }

		public int AgeRating { get; set; }

		public string CountryOfOrigin { get; set; }

		public string ReleasYear { get; set; }

		public string DirectorName { get; set; }

		public string? VideoURl { get; set; }

		public string? ThumbnailImageUrl { get; set; }

		public string? CoverImageUrl { get; set; }
		public string MediaType { get; set; } = "Movie";

	




	}
}
