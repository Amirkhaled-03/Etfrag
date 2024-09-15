
using EtfragApp.BLL.DTOs.Movie;
using EtfragApp.BLL.DTOs.Pages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EtfragApp.BLL.ServicesContracts
{
    public interface IMovieService
    {
        public IEnumerable<MovieDto> GetAll();
        public IEnumerable<MovieDto> GetAllDesc();
        public MovieDto GetById(int id);
        public IEnumerable<MovieDto> GetSpecificNumOfRecordsDescending(int num);

        public void AddMovie(CreateMovieDTO movieDTO);
        public void Delete(int id);
        public void UpdateMovie(EditMovieDto movieDto);
        public void TogglePopularity(int id);
        public PageData<MovieDto> GetPageWithSearch(int pageSize, int pageNo, bool needCount, string searchName);
        public PageData<MovieDto> Getpage(int pageSize, int pageNo, bool needCount);
        public DetailsMovieDto GetMovieDetails(int id);

    }
}
