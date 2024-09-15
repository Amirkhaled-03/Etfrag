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
    public class TVSeriesRepository : GenericRepository<TVSeries>, ITVSeriesRepository
    {
        public TVSeriesRepository(CinemaAppContextMVC context) : base(context)
        {
        }

        public IEnumerable<TVSeries> GetPopularTVSeries()
        {
            var popularMovies = _dbSet.Where(m => m.IsFeatured)
                   .Select(m => new TVSeries
                   {
                       Id = m.Id,
                       ThumbnailImageUrl = m.ThumbnailImageUrl,
                       IsFeatured = m.IsFeatured,
                       Title = m.Title,
                       ReleasYear = m.ReleasYear,
                   });
            return popularMovies;
        }

        public IEnumerable<TVSeries> GetTVSeriesOfTheYear()
        {
            return _dbSet.Where(m => m.ReleasYear == DateTime.Now.Year.ToString())
                   .Select(m => new TVSeries
                   {
                       Id = m.Id,
                       CoverImageUrl = m.CoverImageUrl,
                       IsFeatured = m.IsFeatured,
                       Title = m.Title,
                       ReleasYear = m.ReleasYear,
                   });
        }

        public IEnumerable<TVSeries> SearchByTitle(string searchName)
        {
            return _context.TVSeries.Where(
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
        public List<string> GetMovieCategoriesName(int id)
        {
            List<string> categories = (from TVSeriesCategory in _context.TVSeriesCategories
                                       join Category in _context.Categories
                                       on TVSeriesCategory.CategoryId equals Category.CategoryId
                                       where TVSeriesCategory.TVSeriesId == id
                                       select Category.CategoryName).ToList();


            return categories;
        }

        public IEnumerable<TVSeries> GetPageWithSearch(int pageSize, int pageNo, out int? count, bool needTotalCount, string searchName)
        {
            var query = _dbSet.Where(
              series => series.Title
                    .Trim()
                    .ToLower()
                    .Contains
                     (
                      searchName.Trim()
                      .ToLower()

              ));

            count = needTotalCount ? query.Count() : null;
            return query.Skip((pageNo - 1) * pageSize).Take(pageSize);
        }
    }
}
