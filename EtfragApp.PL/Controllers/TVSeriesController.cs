
using EtfragApp.BLL.DTOs.Pages;
using EtfragApp.BLL.DTOs.TVSeries;
using EtfragApp.BLL.ServicesContracts;
using EtfragApp.PL.Models.Media;
using EtfragApp.PL.Models.Page;
using EtfragApp.PL.Models.TVShow;
using Microsoft.AspNetCore.Mvc;

namespace EtfragApp.PL.Controllers
{
    public class TVSeriesController : Controller
    {
        private readonly ITVSeriesService _tVSeriesService;
        private readonly IActorService _actorService;
        private readonly ICategoryService _categoryService;

        public TVSeriesController(
            ITVSeriesService tVSeriesService,
            IActorService actorService,
            ICategoryService categoryService)
        {
            _tVSeriesService = tVSeriesService;
            _actorService = actorService;
            _categoryService = categoryService;
        }

        public IActionResult Index(int pageSize = 7, int pageNo = 1, bool needCount = true, string? searchValue = null)
        {
            ViewData["SearchValue"] = searchValue;

            return View(GetPage(pageSize, pageNo, needCount, searchValue));
        }

        public IActionResult Create()
        {
            ViewBag.Actors = _actorService.GetData(a => new { a.ActorId, FullName = a.FirstName + " " + a.LastName });
            ViewBag.Categories = _categoryService.GetData(c => new { c.CategoryId, c.CategoryName });

            return View(new CreateTVSeriesVM());
        }

        [HttpPost]
        [RequestSizeLimit(100_000_000)]
        public IActionResult Create(CreateTVSeriesVM model)
        {
            ViewBag.Actors = _actorService.GetData(a => new { a.ActorId, FullName = a.FirstName + " " + a.LastName });
            ViewBag.Categories = _categoryService.GetData(c => new { c.CategoryId, c.CategoryName });

            if (ModelState.IsValid)
            {
                var tVSeries = new CreateTVSeriesDto
                {
                    Title = model.Title,
                    Description = model.Description,
                    ReleasYear = model.ReleasYear,
                    Quality = model.Quality,
                    AgeRating = model.AgeRating,
                    CountryOfOrigin = model.CountryOfOrigin,
                    DirectorName = model.DirectorName,
                    ActorIDs = model.ActorIDs,
                    CategoriesIDs = model.CategoriesIDs,
                    ThumbnailImage = model.ThumbnailImage,
                    CoverImage = model.CoverImage,
                    Episodes = model.Episodes,
                    MediaType = model.MediaType,
                };

                _tVSeriesService.AddTVSeries(tVSeries);

                return RedirectToAction("Index");
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var tVSeriesDto = _tVSeriesService.GetById(id);

            EditTVSeriesVM tvseries = new EditTVSeriesVM()
            {
                ThumbnailImageUrl = tVSeriesDto.ThumbnailImageUrl,
                CoverImageUrl = tVSeriesDto.CoverImageUrl,
                Title = tVSeriesDto.Title,
                Description = tVSeriesDto.Description,
                ReleasYear = tVSeriesDto.ReleasYear,
                Quality = tVSeriesDto.Quality,
                AgeRating = tVSeriesDto.AgeRating,
                CountryOfOrigin = tVSeriesDto.CountryOfOrigin,
                DirectorName = tVSeriesDto.DirectorName,
                Episodes = tVSeriesDto.Episodes,
                

            };


            //     ViewBag.Actors = _tVSeriesService.GetEntityData(a => new { a.ActorId, FullName = a.FirstName + " " + a.LastName });
            //   ViewBag.Categories = _unitOfWork.CategoryRepository.GetEntityData(c => new { c.CategoryId, c.CategoryName });

            return View(tvseries);
        }

        [HttpPost]

        public IActionResult Delete(int id)
        {
            var tvSeries = _tVSeriesService.GetById(id);
            if (tvSeries == null)
                return NotFound();

            _tVSeriesService.Delete(id);

            TempData["Message"] = "media deleted successfuly";
            return RedirectToAction("Index");
        }

        public IActionResult TogglePopularity(int id)
        {
            var movie = _tVSeriesService.GetById(id);

            if (movie != null)
                _tVSeriesService.TogglePopularity(id);

            return RedirectToAction("Index");
        }

        public IActionResult Details(int id,int episodeNum = 1)
        {
            return View(_tVSeriesService.GetTVSeriesDetails(id,episodeNum));
        }

        public PageDataVM<TVSeriesTableVM> GetPage(int pageSize, int pageNo, bool needCount, string? searchValue)
        {
            List<TVSeriesTableVM> mappedTVSeries = new List<TVSeriesTableVM>();
            PageData<TVSeriesDto> TVSeriesPageData;


            if (searchValue is null)
                TVSeriesPageData = _tVSeriesService.Getpage(pageSize, pageNo, needCount);
            else
                TVSeriesPageData = _tVSeriesService.GetPageWithSearch(pageSize, pageNo, needCount, searchValue);

            mappedTVSeries = TVSeriesPageData.Data.Select(s => new TVSeriesTableVM
            {
                Id = s.Id,
                Title = s.Title,
                Duration = s.Duration,
                AddedAt = DateTime.Now,
                AgeRating = s.AgeRating,
                CountryOfOrigin = s.CountryOfOrigin,
                IsFeatured = s.IsFeatured,
            }).ToList();

            return new PageDataVM<TVSeriesTableVM>
            {
                Data = mappedTVSeries,
                PageNumber = pageNo,
                PageSize = pageSize,
                TotalRecords = TVSeriesPageData.TotalRecords,
            };
        }
    }
}
