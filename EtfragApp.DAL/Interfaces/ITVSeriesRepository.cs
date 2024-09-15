using EtfragApp.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EtfragApp.BLL.Interfaces
{
	public interface ITVSeriesRepository:IGenericRepository<TVSeries>
	{
		public IEnumerable<TVSeries> GetPopularTVSeries();
		public List<string> GetMovieCategoriesName(int id);

		public IEnumerable<TVSeries> GetTVSeriesOfTheYear();
		public IEnumerable<TVSeries> SearchByTitle(string searchName);

		public IEnumerable<TVSeries> GetPageWithSearch(int pageSize, int pageNo, out int? count, bool needTotalCount, string searchName);

	}
}
