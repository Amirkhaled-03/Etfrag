using EtfragApp.BLL.Interfaces;
using EtfragApp.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EtfragApp.BLL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CinemaAppContextMVC _cinemaDbContext;

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

        public UnitOfWork(
            CinemaAppContextMVC cinemaDbContext,

            IMovieRepository filmRepository,
            ITVSeriesRepository tvSeriesRepository,
            IActorRepository actorRepository,
            ICategoryRepository categoryRepository,
            IMediaRepository mediaRepository,
            IMovieActorRepository movieActorRepository,
            IMovieCategoryRepository movieCategoryRepository,
            ITVSeriesActorRepository tVSeriesActorRepository,
            ITVSeriesCategoryRepository tVSeriesCategoryRepository,
            IEpisodeRepository episodeRepository
            )
        {
            _cinemaDbContext = cinemaDbContext;

            MovieRepository = filmRepository;
            TVSeriesRepository = tvSeriesRepository;
            ActorRepository = actorRepository;
            CategoryRepository = categoryRepository;
            MediaRepository = mediaRepository;
            MovieActorRepository = movieActorRepository;
            MovieCategoryRepository = movieCategoryRepository;
            TVSeriesActorRepository = tVSeriesActorRepository;
            TVSeriesCategoryRepository = tVSeriesCategoryRepository;
            EpisodeRepository = episodeRepository;
        }

        public void Save()
        {
            _cinemaDbContext.SaveChanges();
        }
    }
}
