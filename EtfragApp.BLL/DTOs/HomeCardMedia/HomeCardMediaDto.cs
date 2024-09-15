using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EtfragApp.BLL.DTOs.HomeCardMedia
{
    public class HomeCardMediaDto
    {
        public int Id { get; set; }
        public string? Image { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public string ReleasYear { get; set; }
        public string Type { get; set; }

        public Guid Guid { get; set; }
    }
}
