using EtfragApp.PL.Models.Actor;
using EtfragApp.PL.Models.Category;
using EtfragApp.PL.Models.Media;
using System.Drawing.Printing;

namespace EtfragApp.PL.Models.Admin
{
    public class DashboardVM
    {
        public int TotalMovies { get; set; }    
        public int TotalTVSeries { get; set; }    
        public int TotalActors { get; set; }    
        public int TotatalCategories { get; set; }    
        public List<ActorTableVM> Actors {  get; set; } = new List<ActorTableVM>();
        public List<CategoryTableVM> Categories { get; set; } = new List<CategoryTableVM> ();
        public List<MovieTableVM> Movies { get; set; } = new List<MovieTableVM>();
        public List<TVSeriesTableVM> TVSeries { get; set; } = new List<TVSeriesTableVM>();
    }

}
