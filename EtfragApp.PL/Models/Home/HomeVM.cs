
using EtfragApp.BLL.DTOs.HomeCardMedia;

namespace EtfragApp.PL.Models.Home
{
    public class HomeVM
    {
        public IEnumerable<HomeCardMediaDto> PopularMedias { get; set; }
        public IEnumerable<HomeCardMediaDto> MediasOfTheYear { get; set; }
        public IEnumerable<HomeCardMediaDto> Movies { get; set; }
        public IEnumerable<HomeCardMediaDto> TVSeries { get; set; }


    }
}
