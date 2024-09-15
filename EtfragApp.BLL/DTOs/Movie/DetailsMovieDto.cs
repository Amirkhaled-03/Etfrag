using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EtfragApp.BLL.DTOs.Movie
{
    public class DetailsMovieDto
    {
        public string? ThumbnailImageUrl { get; set; }

        public string Title { get; set; }
        public string VideoURl { get; set; }
        public string CoverImageUrl { get; set; }
        public string Description { get; set; }
        public int AgeRating { get; set; }
        public int Duration { get; set; }
        public string Quality { get; set; }
        public string ReleasYear { get; set; }
        public string Type { get; set; }
        public List<string> categories { get; set; }
    }
}
