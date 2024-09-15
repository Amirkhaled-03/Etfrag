using EtfragApp.BLL.DTOs.HomeCardMedia;
using EtfragApp.BLL.DTOs.Movie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EtfragApp.BLL.ServicesContracts
{
	public interface IHomeService
	{
		public IEnumerable<HomeCardMediaDto> GetPopularMedias();
		public IEnumerable<HomeCardMediaDto> GetMediasOfTheYear();
		public IEnumerable<HomeCardMediaDto> GetLatestMovies();
		public IEnumerable<HomeCardMediaDto> GetLatestTVSSeries();
		public IEnumerable<HomeCardMediaDto> GetMovieByTitle(string title);
		public IEnumerable<HomeCardMediaDto> GetTVSeriesByTitle(string title);

    }
}
