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
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(CinemaAppContextMVC context) : base(context)
        {
        }

        public int GetTotalFilmsInCategory(int categoryId)
        {
            return _context.MovieCategories.Count(c => c.CategoryId == categoryId);
        }

        public int GetTotalSeriesInCategory(int categoryId)
        {
            return _context.TVSeriesCategories.Count(c => c.CategoryId == categoryId);
        }

        public IEnumerable<Category> GetPageWithSearch(int pageSize, int pageNo, out int? count, bool needTotalCount, string searchName)
        {
            var query = _dbSet.Where(
             c => c.CategoryName
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
