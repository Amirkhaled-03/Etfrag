using EtfragApp.BLL.DTOs.Actor;
using EtfragApp.BLL.DTOs.Movie;
using EtfragApp.BLL.DTOs.Pages;
using EtfragApp.BLL.DTOs.TVSeries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EtfragApp.BLL.ServicesContracts
{
    public interface ITVSeriesService
    {
        public IEnumerable<TVSeriesDto> GetAll();
        public IEnumerable<TVSeriesDto> GetAllDesc();
        public TVSeriesDto GetById(int id);
        // public List<TResult> GetData<TResult>(Func<TVSeries, TResult> selector);
        public IEnumerable<TVSeriesDto> GetSpecificNumOfRecordsDescending(int num);

        public void AddTVSeries(CreateTVSeriesDto TVSeriesDto);
        //  public int AddWithReturnID(TVSeries tvSeries);
        public void Delete(int id);
        public void Update(EditTVSeriesDto tvSeriesDto);
        public void TogglePopularity(int id);
        public DetailsTVSeriesDto GetTVSeriesDetails(int id, int episodeNum);
        public PageData<TVSeriesDto> GetPageWithSearch(int pageSize, int pageNo, bool needCount, string searchName);

        public PageData<TVSeriesDto> Getpage(int pageSize, int pageNo, bool needCount);

    }
}
