using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EtfragApp.DAL.Entities
{
    public class Episode:BaseEntity
    {
        public int EpisodeId { get; set; }
        public int EpisodeNumber { get; set; }
        public string EpisodeURL { get; set; }
        public decimal Duration { get; set; }

        public int TVSeriesId { get; set; }

        public TVSeries TVSeries { get; set; }


    }
}
