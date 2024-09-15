
using EtfragApp.BLL.DTOs.Movie;
using EtfragApp.BLL.DTOs.Pages;
using EtfragApp.BLL.ServicesContracts;
using EtfragApp.PL.Models.Media;
using EtfragApp.PL.Models.Movie;
using EtfragApp.PL.Models.Page;
using Microsoft.AspNetCore.Mvc;

namespace EtfragApp.PL.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieService _movieService;
        private readonly IActorService _actorService;
        private readonly ICategoryService _categoryService;


        public MovieController(IMovieService movieService, IActorService actorService, ICategoryService categoryService)
        {
            _movieService = movieService;
            _actorService = actorService;
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
            // ViewBag.Actors = _actorService.GetAll();
            ViewBag.Actors = _actorService.GetData(a => new { a.ActorId, FullName = a.FirstName + " " + a.LastName });
            ViewBag.Categories = _categoryService.GetData(c => new { c.CategoryId, c.CategoryName });

            return View("Create");
        }

        [HttpPost]
        [RequestSizeLimit(300_000_000)]
        public IActionResult Create(CreateMovieVM model)
        {
            ViewBag.Actors = _actorService.GetData(a => new { a.ActorId, FullName = a.FirstName + " " + a.LastName });
            ViewBag.Categories = _categoryService.GetData(c => new { c.CategoryId, c.CategoryName });

            if (ModelState.IsValid)
            {
                CreateMovieDTO movieDTO = new CreateMovieDTO
                {
                    Title = model.Title,
                    ThumbnailImage = model.ThumbnailImage,
                    CoverImage = model.CoverImage,
                    MediaVideo = model.MediaVideo,
                    AgeRating = model.AgeRating,
                    ActorIDs = model.ActorIDs,
                    CategoriesIDs = model.CategoriesIDs,
                    CountryOfOrigin = model.CountryOfOrigin,
                    Description = model.Description,
                    DirectorName = model.DirectorName,
                    MediaType = model.MediaType,
                    Duration = model.Duration,
                    Quality = model.Quality,
                    ReleasYear = model.ReleasYear,
                };

                _movieService.AddMovie(movieDTO);

                return RedirectToAction("Index");
            }


            return View(model);
        }

        public IActionResult Update(int id)
        {
            var movie = _movieService.GetById(id);

            MovieEditVM model = new MovieEditVM()
            {
                ThumbnailImageUrl = movie.ThumbnailImageUrl,
                CoverImageUrl = movie.CoverImageUrl,
                Title = movie.Title,
                Description = movie.Description,
                ReleasYear = movie.ReleasYear,
                Duration = movie.Duration,
                Quality = movie.Quality,
                AgeRating = movie.AgeRating,
                CountryOfOrigin = movie.CountryOfOrigin,
                DirectorName = movie.DirectorName,
                VideoURl = movie.VideoURl,
            };

            ViewBag.Actors = _actorService.GetData(a => new { a.ActorId, FullName = a.FirstName + " " + a.LastName });
            ViewBag.Categories = _categoryService.GetData(c => new { c.CategoryId, c.CategoryName });

            return View(model);
        }

        [HttpPost]
        public IActionResult Update(int id, MovieEditVM model)
        {
            var movie = _movieService.GetById(id);

            if (movie == null)
                return NotFound();

            if (ModelState.IsValid)
            {
                EditMovieDto movieDto = new EditMovieDto
                {
                    Id = movie.Id,
                    AgeRating = model.AgeRating,
                    CoverImage = model.CoverImage,
                    Title = model.Title,
                    Description = model.Description,
                    Duration = model.Duration,
                    Quality = model.Quality,
                    MediaVideo = model.MediaVideo,
                    ReleasYear = model.ReleasYear,
                    ThumbnailImage = model.ThumbnailImage,
                    DirectorName = model.DirectorName,
                    CountryOfOrigin = model.CountryOfOrigin,
                };

                _movieService.UpdateMovie(movieDto);

                return RedirectToAction("Index");
            }

            ViewBag.Actors = _actorService.GetData(a => new { a.ActorId, FullName = a.FirstName + " " + a.LastName });
            ViewBag.Categories = _categoryService.GetData(c => new { c.CategoryId, c.CategoryName });

            return View(model);
        }

        public IActionResult Delete(int id)
        {
            var movie = _movieService.GetById(id);
            if (movie == null)
                return NotFound();

            _movieService.Delete(id);

            TempData["Message"] = "media deleted successfuly";
            return RedirectToAction("Index");
        }

        public IActionResult TogglePopularity(int id)
        {
            var movie = _movieService.GetById(id);

            if (movie != null)
                _movieService.TogglePopularity(id);

            return RedirectToAction("Index");
        }

        //[Authorize]
        public IActionResult Details(int id)
        {
            return View(_movieService.GetMovieDetails(id));
        }

        public PageDataVM<MovieTableVM> GetPage(int pageSize, int pageNo, bool needCount, string? searchValue)
        {
            List<MovieTableVM> mappedMovies = new List<MovieTableVM>();
            PageData<MovieDto> moviePageData;


            if (searchValue is null)
                moviePageData = _movieService.Getpage(pageSize, pageNo, needCount);
            else
                moviePageData = _movieService.GetPageWithSearch(pageSize, pageNo, needCount, searchValue);

            mappedMovies = moviePageData.Data.Select(mov => new MovieTableVM
            {
                Id = mov.Id,
                Title = mov.Title,
                AgeRating = mov.AgeRating,
                AddedAt = mov.AddedAt,
                IsFeatured = mov.IsFeatured,
            }).ToList();

            return new PageDataVM<MovieTableVM>
            {
                Data = mappedMovies,
                PageNumber = pageNo,
                PageSize = pageSize,
                TotalRecords = moviePageData.TotalRecords,
            };
        }

    }
}
