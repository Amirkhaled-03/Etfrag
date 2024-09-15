using EtfragApp.BLL.Interfaces;
using EtfragApp.DAL.Context;
using EtfragApp.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EtfragApp.BLL.Repositories
{
    public class MovieRepository : GenericRepository<Movie>, IMovieRepository
    {
        public MovieRepository(CinemaAppContextMVC context) : base(context)
        {
        }

        public IEnumerable<Movie> GetPopularMovie()
        {
            var popularMovies = _dbSet.Where(m => m.IsFeatured)
                   .Select(m => new Movie
                   {
                       Id = m.Id,
                       ThumbnailImageUrl = m.ThumbnailImageUrl,
                       IsFeatured = m.IsFeatured,
                       Title = m.Title,
                       ReleasYear = m.ReleasYear,
                   });
            return popularMovies;
        }

        public IEnumerable<Movie> GetMovieOfTheYear()
        {
            var res = _dbSet.Where(m => m.ReleasYear == DateTime.Now.Year.ToString())
                   .Select(m => new Movie
                   {
                       Id = m.Id,
                       CoverImageUrl = m.CoverImageUrl,
                       IsFeatured = m.IsFeatured,
                       Title = m.Title,
                       ReleasYear = m.ReleasYear,
                   });
            return res;
        }

        public List<string> GetMovieCategoriesName(int id)
        {
            List<string> categories = (from MovieCategory in _context.MovieCategories
                                       join Category in _context.Categories
                                       on MovieCategory.CategoryId equals Category.CategoryId
                                       where MovieCategory.MediaId == id
                                       select Category.CategoryName).ToList();


            return categories;
        }

        public IEnumerable<Movie> GetPageWithSearch(int pageSize, int pageNo, out int? count, bool needTotalCount, string searchName)
        {
            var query = _context.Movies.Where(
              m => m.Title
                    .Trim()
                    .ToLower()
                    .Contains
                     (
                      searchName.Trim()
                      .ToLower()
                     )
              );

            count = needTotalCount ? query.Count() : null;
            return query.Skip((pageNo - 1) * pageSize).Take(pageSize);

        }

        public IEnumerable<Movie> SearchByTitle(string searchName)
        {
            return _context.Movies.Where(
               m => m.Title
                     .Trim()
                     .ToLower()
                     .Contains
                      (
                       searchName.Trim()
                       .ToLower()
                      )
               );
        }
    }
}
