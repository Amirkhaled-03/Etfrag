using EtfragApp.BLL.DTOs.Episode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EtfragApp.BLL.DTOs.TVSeries
{
    public class DetailsTVSeriesDto
    {
        public string? ThumbnailImageUrl { get; set; }

        public string Title { get; set; }
        public string CoverImageUrl { get; set; }
        public string Description { get; set; }
        public int AgeRating { get; set; }
        public int Duration { get; set; }
        public string Quality { get; set; }
        public string ReleasYear { get; set; }
        public string Type { get; set; }
        public List<string> categories { get; set; }
        public List<EpisodeDto> Episodies { get; set; } = new List<EpisodeDto>();
        public int EpisodeNum { get; set; }


    }
}
