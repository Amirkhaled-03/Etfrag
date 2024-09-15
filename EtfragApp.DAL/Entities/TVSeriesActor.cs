using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EtfragApp.DAL.Entities
{
    public class TVSeriesActor :BaseEntity
    {
        public int ActorId { get; set; }
        public Actor Actor { get; set; }

        public int TVSeriesId { get; set; }
        public TVSeries TVSeries { get; set; }
    }
}
