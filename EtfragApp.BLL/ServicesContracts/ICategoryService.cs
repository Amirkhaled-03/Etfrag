using EtfragApp.BLL.DTOs.Category;
using EtfragApp.BLL.DTOs.Pages;
using EtfragApp.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EtfragApp.BLL.ServicesContracts
{
    public interface ICategoryService
    {
        public IEnumerable<Category> GetAll();
        public Category GetById(int id);
        public List<TResult> GetData<TResult>(Func<Category, TResult> selector);
        public IEnumerable<CategoryDto> GetSpecificNumOfRecordsDescending(int num);

        public void Add(Category category);
        public void Delete(int id);
        public void Update(Category category);
        public int GetTotalSeriesInCategory(int categoryId);
        public int GetTotalFilmsInCategory(int categoryId);

        public PageData<CategoryDto> GetPageWithSearch(int pageSize, int pageNo, bool needCount, string searchName);
        public PageData<CategoryDto> Getpage(int pageSize, int pageNo, bool needCount);

        // public PageData<Category> Getpage(int pageSize, int pageNo, bool needCount);
    }
}
