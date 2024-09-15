
using EtfragApp.BLL.DTOs.Category;
using EtfragApp.BLL.DTOs.Pages;
using EtfragApp.BLL.ServicesContracts;
using EtfragApp.DAL.Entities;
using EtfragApp.PL.Models.Category;
using EtfragApp.PL.Models.Page;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EtfragApp.PL.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IActionResult Index(int pageSize = 7, int pageNo = 1, bool needCount = true, string? searchValue = null)
        {
            // Store the search value in ViewData to keep it in the form
            ViewData["SearchValue"] = searchValue;

            return View(GetPage(pageSize, pageNo, needCount, searchValue));
        }

        public IActionResult Create()
        {
            return View(new CategoryVM());
        }

        [HttpPost]
        public IActionResult Create(CategoryVM model)
        {
            if (ModelState.IsValid)
            {
                Category category = new Category
                {
                    CategoryName = model.CategoryName,
                };

                _categoryService.Add(category);

                return RedirectToAction("Index", "Category");
            }
            return View(model);
        }

        public IActionResult Delete(int id)
        {
            var category = _categoryService.GetById(id);
            if (category != null)
            {
                _categoryService.Delete(id);
            }

            return RedirectToAction("Index");

        }

        public IActionResult Update(int id)
        {
            var category = _categoryService.GetById(id);
            if (category == null)
                return NotFound();

            CategoryVM mappedCategory = new CategoryVM
            {
                CategoryName = category.CategoryName,
            };

            return View(mappedCategory);
        }

        [HttpPost]
        public IActionResult Update(int id, CategoryVM model)
        {
            Category category = _categoryService.GetById(id);
            if (category is null)
                return NotFound();

            category.CategoryName = model.CategoryName;

            _categoryService.Update(category);

            return RedirectToAction("Index", "Category");
        }

        public PageDataVM<CategoryTableVM> GetPage(int pageSize, int pageNo, bool needCount, string? searchValue)
        {
            CategoryTableVM categoryTableVM;
            List<CategoryTableVM> mappedCategories = new List<CategoryTableVM>();
            PageData<CategoryDto> CategoriesPageData;


            if (searchValue is null)
                CategoriesPageData = _categoryService.Getpage(pageSize, pageNo, needCount);
            else
                CategoriesPageData = _categoryService.GetPageWithSearch(pageSize, pageNo, needCount, searchValue);


            foreach (var category in CategoriesPageData.Data)
            {
                categoryTableVM = new CategoryTableVM()
                {
                    CategoryId = category.CategoryId,
                    CategoryName = category.CategoryName,
                    AddedAt = category.AddedAt,
                };

                categoryTableVM.TotalFilmsInThisCategory = _categoryService.GetTotalFilmsInCategory(category.CategoryId);
                categoryTableVM.TotalSeriesInThisCategory = _categoryService.GetTotalSeriesInCategory(category.CategoryId);

                mappedCategories.Add(categoryTableVM);
            }

            return new PageDataVM<CategoryTableVM>
            {
                Data = mappedCategories,
                PageNumber = pageNo,
                PageSize = pageSize,
                TotalRecords = CategoriesPageData.TotalRecords,
            };
        }


    }
}
