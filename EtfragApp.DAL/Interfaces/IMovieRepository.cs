using EtfragApp.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EtfragApp.BLL.Interfaces
{
	public interface IMovieRepository : IGenericRepository<Movie>
	{
		public IEnumerable<Movie> GetPopularMovie();
		public List<string> GetMovieCategoriesName(int id);
		public IEnumerable<Movie> GetPageWithSearch(int pageSize, int pageNo, out int? count, bool needTotalCount, string searchName);
		public IEnumerable<Movie> GetMovieOfTheYear();
		public IEnumerable<Movie> SearchByTitle(string searchName);



    }
}
