using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EtfragApp.BLL.Interfaces
{
	public interface IUnitOfWork
	{
		public IMovieRepository MovieRepository { get; set; }
		public ITVSeriesRepository TVSeriesRepository { get; set; }
		public IActorRepository ActorRepository { get; set; }
		public ICategoryRepository CategoryRepository { get; set; }

		public IMediaRepository MediaRepository { get; set; }	

		public IMovieActorRepository MovieActorRepository { get; set; }
		public IMovieCategoryRepository MovieCategoryRepository { get; set; }	

		public ITVSeriesActorRepository TVSeriesActorRepository { get; set; }
		public ITVSeriesCategoryRepository TVSeriesCategoryRepository { get; set; }	
		public IEpisodeRepository EpisodeRepository { get; set; }

		public void Save() { }
	}
}
