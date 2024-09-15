using EtfragApp.BLL.DTOs.Category;
using EtfragApp.BLL.DTOs.Pages;
using EtfragApp.BLL.Interfaces;
using EtfragApp.BLL.ServicesContracts;
using EtfragApp.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace EtfragApp.BLL.Sevices
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Add(Category category)
        {
            _unitOfWork.CategoryRepository.AddEntity(category);
            _unitOfWork.Save();
        }

        public void Delete(int id)
        {
            _unitOfWork.CategoryRepository.DeleteEntity(id);
            _unitOfWork.Save();
        }

        public IEnumerable<Category> GetAll()
        {
            return _unitOfWork.CategoryRepository.GetAll();
        }

        public Category GetById(int id)
        {
            return _unitOfWork.CategoryRepository.GetEntityById(id);
        }

        public List<TResult> GetData<TResult>(Func<Category, TResult> selector)
        {
            return _unitOfWork.CategoryRepository.GetEntityData<TResult>(selector);
        }

        public IEnumerable<CategoryDto> GetSpecificNumOfRecordsDescending(int num)
        {
            var categories = _unitOfWork.CategoryRepository.GetSpecificNumOfRecordsDescending(num);

            return categories.Select(c => new CategoryDto
            {
                CategoryId = c.CategoryId,
                CategoryName = c.CategoryName,
                AddedAt = c.AddedAt
            }
            );
        }

        public void Update(Category category)
        {
            _unitOfWork.CategoryRepository.UpdateEntity(category);
            _unitOfWork.Save();
        }

        public int GetTotalFilmsInCategory(int categoryId)
        {
            return _unitOfWork.CategoryRepository.GetTotalFilmsInCategory(categoryId);
        }
        public int GetTotalSeriesInCategory(int categoryId)
        {
            return _unitOfWork.CategoryRepository.GetTotalSeriesInCategory(categoryId);
        }

        public PageData<CategoryDto> Getpage(int pageSize, int pageNo, bool needCount)
        {
            int? totalCount;
            var categories = _unitOfWork.CategoryRepository.Getpage(pageSize, pageNo, out totalCount, needCount);

            return new PageData<CategoryDto>
            {
                Data = categories.Select(category => new CategoryDto
                {
                    CategoryId = category.CategoryId,
                    CategoryName = category.CategoryName,
                    AddedAt = category.AddedAt

                }).ToList(),
                TotalRecords = totalCount
            };
        }

        public PageData<CategoryDto> GetPageWithSearch(int pageSize, int pageNo, bool needCount, string searchName)
        {
            int? totalCount;
            var categories = _unitOfWork.CategoryRepository.GetPageWithSearch(pageSize, pageNo, out totalCount, needCount, searchName);

            return new PageData<CategoryDto>
            {
                Data = categories.Select(category => new CategoryDto
                {
                    CategoryId = category.CategoryId,
                    CategoryName = category.CategoryName,
                    AddedAt = category.AddedAt

                }).ToList(),
                TotalRecords = totalCount
            };
        }

    }

}
