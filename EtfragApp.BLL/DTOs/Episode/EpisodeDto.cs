using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EtfragApp.BLL.DTOs.Episode
{
    public class EpisodeDto
    {
        public int Id { get; set; }
        public decimal Duration { get; set; }

        public string EpisodeURL { get; set; }
    }
}
