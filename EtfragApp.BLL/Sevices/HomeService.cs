using EtfragApp.BLL.DTOs.HomeCardMedia;
using EtfragApp.BLL.Interfaces;
using EtfragApp.BLL.ServicesContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EtfragApp.BLL.Sevices
{
    public class HomeService : IHomeService
    {
        private readonly IUnitOfWork _unitOfWork;

        public HomeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<HomeCardMediaDto> GetPopularMedias()
        {
            var movies = _unitOfWork.MovieRepository.GetPopularMovie().ToList();
            var TVSeries = _unitOfWork.TVSeriesRepository.GetPopularTVSeries().ToList();


            var mappedMovies = movies.Select(m => new HomeCardMediaDto
            {
                Id = m.Id,
                Title = m.Title,
                Image = m.ThumbnailImageUrl,
                ReleasYear = m.ReleasYear,
                Type = "Movie",
                Category = _unitOfWork.MovieRepository.GetMovieCategoriesName(m.Id).FirstOrDefault()
            }
               );

            var mappedTVSeries = TVSeries.Select(m => new HomeCardMediaDto
            {
                Id = m.Id,
                Title = m.Title,
                Image = m.ThumbnailImageUrl,
                ReleasYear = m.ReleasYear,
                Type = "TVSeries",
                Category = _unitOfWork.TVSeriesRepository.GetMovieCategoriesName(m.Id).FirstOrDefault()
            }
              );

            return mappedMovies.Concat(mappedTVSeries);
        }

        public IEnumerable<HomeCardMediaDto> GetMediasOfTheYear()
        {
            var movies = _unitOfWork.MovieRepository.GetMovieOfTheYear().ToList();
            var TVSeries = _unitOfWork.TVSeriesRepository.GetTVSeriesOfTheYear().ToList();


            var mappedMovies = movies.Select(m => new HomeCardMediaDto
            {
                Id = m.Id,
                Title = m.Title,
                ReleasYear = m.ReleasYear,
                Image = m.CoverImageUrl,
                Type = "Movie",
                Guid = Guid.NewGuid(),
                Category = _unitOfWork.MovieRepository.GetMovieCategoriesName(m.Id).FirstOrDefault()

            }
               );

            var mappedTVSeries = TVSeries.Select(m => new HomeCardMediaDto
            {
                Id = m.Id,
                Title = m.Title,
                Image = m.CoverImageUrl,
                ReleasYear = m.ReleasYear,
                Type = "TVSeries",
                Guid = Guid.NewGuid(),
                Category = _unitOfWork.TVSeriesRepository.GetMovieCategoriesName(m.Id).FirstOrDefault()
            }
              );

            return mappedMovies.Concat(mappedTVSeries).OrderBy(x => x.Guid);
        }

        public IEnumerable<HomeCardMediaDto> GetLatestMovies()
        {
            var movies = _unitOfWork.MovieRepository.GetAll();

            var mappedMovies = movies.Select(m => new HomeCardMediaDto
            {
                Id = m.Id,
                Title = m.Title,
                ReleasYear = m.ReleasYear,
                Image = m.ThumbnailImageUrl,
                Type = "Movie",
                Guid = Guid.NewGuid(),
                Category = _unitOfWork.MovieRepository.GetMovieCategoriesName(m.Id).FirstOrDefault()
            }
               );

            return mappedMovies.OrderBy(x => x.Guid);
        }

        public IEnumerable<HomeCardMediaDto> GetLatestTVSSeries()
        {
            var tvseries = _unitOfWork.TVSeriesRepository.GetAll();

            var mappedTvseries = tvseries.Select(m => new HomeCardMediaDto
            {
                Id = m.Id,
                Title = m.Title,
                ReleasYear = m.ReleasYear,
                Image = m.ThumbnailImageUrl,
                Type = "TVSeries",
                Guid = new Guid(),
                Category = _unitOfWork.TVSeriesRepository.GetMovieCategoriesName(m.Id).FirstOrDefault()
            }

               );
            return mappedTvseries;
        }

        public IEnumerable<HomeCardMediaDto> GetMovieByTitle(string title)
        {
            var movies = _unitOfWork.MovieRepository.SearchByTitle(title).ToList();

            var mappedMovies = movies.Select(m => new HomeCardMediaDto
            {
                Id = m.Id,
                Title = m.Title,
                ReleasYear = m.ReleasYear,
                Image = m.ThumbnailImageUrl,
                Type = "Movie",
                Guid = Guid.NewGuid(),
                Category = _unitOfWork.MovieRepository.GetMovieCategoriesName(m.Id).FirstOrDefault()
            }
               );

            return mappedMovies;
        }

        public IEnumerable<HomeCardMediaDto> GetTVSeriesByTitle(string title)
        {
            var tvseries = _unitOfWork.TVSeriesRepository.SearchByTitle(title).ToList();

            var mappedTvseries = tvseries.Select(m => new HomeCardMediaDto
            {
                Id = m.Id,
                Title = m.Title,
                ReleasYear = m.ReleasYear,
                Image = m.ThumbnailImageUrl,
                Type = "TVSeries",
                Guid = new Guid(),
                Category = _unitOfWork.TVSeriesRepository.GetMovieCategoriesName(m.Id).FirstOrDefault()
            }

               );
            return mappedTvseries;
        }
    }
}
