using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EtfragApp.DAL.Entities
{
    public class TVSeries : Media
    {
        public List<Episode> Episodes { get; set; }
        public ICollection<TVSeriesCategory> TVSeriesCategories { get; set; }
        public ICollection<TVSeriesActor> TVSeriesActors { get; set; }
    }
}
