using EtfragApp.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EtfragApp.BLL.Interfaces
{
    public interface ICategoryRepository :IGenericRepository<Category>
    {
        public int GetTotalSeriesInCategory(int categoryId);
        public int GetTotalFilmsInCategory(int categoryId);
        public IEnumerable<Category> GetPageWithSearch(int pageSize, int pageNo, out int? count, bool needTotalCount, string searchName);

    }
}
