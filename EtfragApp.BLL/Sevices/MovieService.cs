using EtfragApp.BLL.DTOs.Movie;
using EtfragApp.BLL.DTOs.Pages;
using EtfragApp.BLL.FileManagement;
using EtfragApp.BLL.Interfaces;
using EtfragApp.BLL.ServicesContracts;
using EtfragApp.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EtfragApp.BLL.Sevices
{
    public class MovieService : IMovieService
    {
        public IUnitOfWork _unitOfWork;

        public MovieService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void AddMovie(CreateMovieDTO movieDto)
        {
            var movie = new Movie
            {
                Title = movieDto.Title,
                Description = movieDto.Description,
                ReleasYear = movieDto.ReleasYear,
                Duration = movieDto.Duration,
                Quality = movieDto.Quality,
                AgeRating = movieDto.AgeRating,
                CountryOfOrigin = movieDto.CountryOfOrigin,
                DirectorName = movieDto.DirectorName,


                ThumbnailImageUrl = DocumentsSettings.UploadFile(movieDto.ThumbnailImage, "Posters"),
                CoverImageUrl = DocumentsSettings.UploadFile(movieDto.CoverImage, "Covers"),
                VideoURl = DocumentsSettings.UploadFile(movieDto.MediaVideo, "Videos"),
            };

            var movieActors = movieDto.ActorIDs.Select(actorID => new MovieActor
            {
                ActorId = actorID,
            }).ToList();

            movie.MovieActors = movieActors;

            var mediaCategories = movieDto.CategoriesIDs.Select(categoryID => new MovieCategory
            {
                CategoryId = categoryID,
            }).ToList();

            movie.MovieCategories = mediaCategories;

            _unitOfWork.MovieRepository.AddEntity(movie);

            _unitOfWork.Save();
        }

        public void Delete(int id)
        {
            _unitOfWork.MovieRepository.DeleteEntity(id);
            _unitOfWork.Save();
        }

        public IEnumerable<MovieDto> GetAll()
        {
            List<Movie> movies = _unitOfWork.MovieRepository.GetAll().ToList();

            return movies.Select(mov => new MovieDto
            {
                Id = mov.Id,
                ThumbnailImageUrl = mov.ThumbnailImageUrl,
                Title = mov.Title,
                VideoURl = mov.VideoURl,
                AgeRating = mov.AgeRating,
                CountryOfOrigin = mov.CountryOfOrigin,
                CoverImageUrl = mov.CoverImageUrl,
                Description = mov.Description,
                DirectorName = mov.DirectorName,
                Duration = mov.Duration,
                Quality = mov.Quality,
                ReleasYear = mov.ReleasYear,
                AddedAt = mov.AddedAt,
                IsFeatured = mov.IsFeatured,
            });
        }

        public IEnumerable<MovieDto> GetAllDesc()
        {
            List<Movie> movies = _unitOfWork.MovieRepository.GetAllDesc().ToList();

            return movies.Select(mov => new MovieDto
            {
                Id = mov.Id,
                ThumbnailImageUrl = mov.ThumbnailImageUrl,
                Title = mov.Title,
                VideoURl = mov.VideoURl,
                AgeRating = mov.AgeRating,
                CountryOfOrigin = mov.CountryOfOrigin,
                CoverImageUrl = mov.CoverImageUrl,
                Description = mov.Description,
                DirectorName = mov.DirectorName,
                Duration = mov.Duration,
                Quality = mov.Quality,
                ReleasYear = mov.ReleasYear,
                AddedAt = mov.AddedAt,
                IsFeatured = mov.IsFeatured,

            });
        }

        public MovieDto GetById(int id)
        {
            Movie movie = _unitOfWork.MovieRepository.GetEntityById(id);

            return new MovieDto
            {
                Id = movie.Id,
                Title = movie.Title,
                ThumbnailImageUrl = movie.ThumbnailImageUrl,
                CoverImageUrl = movie.CoverImageUrl,
                VideoURl = movie.VideoURl,
                AgeRating = movie.AgeRating,
                CountryOfOrigin = movie.CountryOfOrigin,
                Description = movie.Description,
                DirectorName = movie.DirectorName,
                Duration = movie.Duration,
                Quality = movie.Quality,
                ReleasYear = movie.ReleasYear
            };
        }

        public IEnumerable<MovieDto> GetSpecificNumOfRecordsDescending(int num)
        {
            var movies = _unitOfWork.MovieRepository.GetSpecificNumOfRecordsDescending(num);

            return movies.Select(mov => new MovieDto
            {
                Id = mov.Id,
                Title = mov.Title,
                AddedAt = mov.AddedAt,
            });
        }

        public void UpdateMovie(EditMovieDto MovieDto)
        {
            Movie movie = _unitOfWork.MovieRepository.GetEntityById(MovieDto.Id);

            if (MovieDto.ThumbnailImage != null)
            {
                DocumentsSettings.DeleteFile(movie.ThumbnailImageUrl, "Posters");
                movie.ThumbnailImageUrl = DocumentsSettings.UploadFile(MovieDto.ThumbnailImage, "Posters");
            }

            if (MovieDto.CoverImage != null)
            {
                DocumentsSettings.DeleteFile(movie.CoverImageUrl, "Covers");
                movie.CoverImageUrl = DocumentsSettings.UploadFile(MovieDto.CoverImage, "Covers");
            }

            if (MovieDto.MediaVideo != null)
            {
                DocumentsSettings.DeleteFile(movie.VideoURl, "Videos");
                movie.VideoURl = DocumentsSettings.UploadFile(MovieDto.MediaVideo, "Videos");
            }

            movie.Title = MovieDto.Title;
            movie.Description = MovieDto.Description;
            movie.ReleasYear = MovieDto.ReleasYear;
            movie.Duration = MovieDto.Duration;
            movie.Quality = MovieDto.Quality;
            movie.AgeRating = MovieDto.AgeRating;
            movie.CountryOfOrigin = MovieDto.CountryOfOrigin;

            _unitOfWork.MovieRepository.UpdateEntity(movie);
            _unitOfWork.Save();
        }

        public void TogglePopularity(int id)
        {
            Movie movie = _unitOfWork.MovieRepository.GetEntityById(id);
            movie.IsFeatured = !movie.IsFeatured;
            _unitOfWork.MovieRepository.UpdateEntity(movie);
            _unitOfWork.Save();
        }

        public DetailsMovieDto GetMovieDetails(int id)
        {
            var movie = _unitOfWork.MovieRepository.GetEntityAndRelatsById(id, m => m.MovieCategories);

            List<string> categories = _unitOfWork.MovieRepository.GetMovieCategoriesName(id);

            return new DetailsMovieDto
            {
                Title = movie.Title,
                VideoURl = movie.VideoURl,
                CoverImageUrl = movie.CoverImageUrl,
                Description = movie.Description,
                AgeRating = movie.AgeRating,
                Duration = movie.Duration,
                Quality = movie.Quality,
                ReleasYear = movie.ReleasYear,
                categories = categories
            };
        }

        public PageData<MovieDto> Getpage(int pageSize, int pageNo, bool needCount)
        {
            int? totalCount;
            var movies = _unitOfWork.MovieRepository.Getpage(pageSize, pageNo, out totalCount, needCount);

            return new PageData<MovieDto>
            {
                Data = movies.Select(mov => new MovieDto
                {
                    Id = mov.Id,
                    ThumbnailImageUrl = mov.ThumbnailImageUrl,
                    Title = mov.Title,
                    VideoURl = mov.VideoURl,
                    AgeRating = mov.AgeRating,
                    CountryOfOrigin = mov.CountryOfOrigin,
                    CoverImageUrl = mov.CoverImageUrl,
                    Description = mov.Description,
                    DirectorName = mov.DirectorName,
                    Duration = mov.Duration,
                    Quality = mov.Quality,
                    ReleasYear = mov.ReleasYear,
                    AddedAt = mov.AddedAt,
                    IsFeatured = mov.IsFeatured,

                }).ToList(),
                TotalRecords = totalCount
            };
        }

        public PageData<MovieDto> GetPageWithSearch(int pageSize, int pageNo, bool needCount, string searchName)
        {
            int? totalCount;
            var movies = _unitOfWork.MovieRepository.GetPageWithSearch(pageSize, pageNo, out totalCount, needCount, searchName);

            return new PageData<MovieDto>
            {
                Data = movies.Select(mov => new MovieDto
                {
                    Id = mov.Id,
                    ThumbnailImageUrl = mov.ThumbnailImageUrl,
                    Title = mov.Title,
                    VideoURl = mov.VideoURl,
                    AgeRating = mov.AgeRating,
                    CountryOfOrigin = mov.CountryOfOrigin,
                    CoverImageUrl = mov.CoverImageUrl,
                    Description = mov.Description,
                    DirectorName = mov.DirectorName,
                    Duration = mov.Duration,
                    Quality = mov.Quality,
                    ReleasYear = mov.ReleasYear,
                    AddedAt = mov.AddedAt,
                    IsFeatured = mov.IsFeatured,

                }).ToList(),
                TotalRecords = totalCount
            };
        }

    }
}
