using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EtfragApp.DAL.Entities
{
    public class TVSeriesCategory:BaseEntity
    {
        public int TVSeriesId { get; set; }
        public TVSeries TVSeries { get; set; } 

        public int CategoryId { get; set; }
        public Category Category { get; set; } 

    }
}
