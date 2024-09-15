
using EtfragApp.BLL.DTOs.Actor;
using EtfragApp.BLL.DTOs.Category;
using EtfragApp.BLL.DTOs.Movie;
using EtfragApp.BLL.DTOs.TVSeries;
using EtfragApp.BLL.ServicesContracts;
using EtfragApp.PL.Models.Actor;
using EtfragApp.PL.Models.Admin;
using EtfragApp.PL.Models.Category;
using EtfragApp.PL.Models.Media;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EtfragApp.PL.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly IMovieService _movieService;
        private readonly ITVSeriesService _tvSeriesService;
        private readonly IActorService _actorService;
        private readonly ICategoryService _categoryService;
        private readonly int _MaxSelectedRows = 5;

        public AdminController(
            IMovieService movieService,
            ITVSeriesService tVSeriesService,
            IActorService actorService,
            ICategoryService categoryService
            )
        {
            _movieService = movieService;
            _tvSeriesService = tVSeriesService;
            _actorService = actorService;
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            DashboardVM dashboardVM = new DashboardVM();

            dashboardVM.TotalMovies = _movieService.GetAll().Count();

            dashboardVM.TotalTVSeries = _tvSeriesService.GetAll().Count();

            dashboardVM.TotalActors = _actorService.GetAll().Count();

            dashboardVM.TotatalCategories = _categoryService.GetAll().Count();

            dashboardVM.Actors = GetLatestActors();

            dashboardVM.Categories = GetLatestCategories();

            dashboardVM.Movies = LatestMovies();

            dashboardVM.TVSeries = LatestTVSeries();

            return View(dashboardVM);
        }

        private List<ActorTableVM> GetLatestActors()
        {

            IEnumerable<ActorDto> actors = _actorService.GetSpecificNumOfRecordsDescending(_MaxSelectedRows);
            List<ActorTableVM> mappedActors = new List<ActorTableVM>();
            ActorTableVM mappedActor = null;

            foreach (ActorDto actor in actors)
            {
                mappedActor = new ActorTableVM()
                {
                    Id = actor.ActorId,
                    FirstName = actor.FirstName,
                    LastName = actor.LastName,
                    Nationality = actor.Nationality,
                    AddedAt = actor.AddedAt,
                };

                mappedActor.TotalSeriesInSite = _actorService.GetTotalActorSeriesCount(actor.ActorId);
                mappedActor.TotalFilmsInSite = _actorService.GetTotalActorFilmsCount(actor.ActorId);

                mappedActors.Add(mappedActor);
            }

            return mappedActors;
        }

        private List<CategoryTableVM> GetLatestCategories()
        {
            IEnumerable<CategoryDto> categories = _categoryService.GetSpecificNumOfRecordsDescending(_MaxSelectedRows);
            List<CategoryTableVM> mappedCategories = new List<CategoryTableVM>();
            CategoryTableVM mappedCategory = null;

            foreach (CategoryDto category in categories)
            {
                mappedCategory = new CategoryTableVM()
                {
                    CategoryId = category.CategoryId,
                    CategoryName = category.CategoryName,
                    AddedAt = category.AddedAt,
                };

                mappedCategory.TotalFilmsInThisCategory = _categoryService.GetTotalFilmsInCategory(category.CategoryId);
                mappedCategory.TotalSeriesInThisCategory = _categoryService.GetTotalSeriesInCategory(category.CategoryId);

                mappedCategories.Add(mappedCategory);
            }

            return mappedCategories;
        }

        private List<MovieTableVM> LatestMovies()
        {

            IEnumerable<MovieDto> movies = _movieService.GetSpecificNumOfRecordsDescending(_MaxSelectedRows);
            List<MovieTableVM> mappedMovies = new List<MovieTableVM>();

            foreach (MovieDto movie in movies)
            {
                mappedMovies.Add(new MovieTableVM()
                {
                    Id = movie.Id,
                    Title = movie.Title,
                    AddedAt = movie.AddedAt,
                });
            }

            return mappedMovies;
        }

        private List<TVSeriesTableVM> LatestTVSeries()
        {
            IEnumerable<TVSeriesDto> tVSeries = _tvSeriesService.GetSpecificNumOfRecordsDescending(_MaxSelectedRows);

            return tVSeries.Select(ts => new TVSeriesTableVM
            {
                Id = ts.Id,
                Title = ts.Title,
                AddedAt = ts.AddedAt,
            }).ToList();

        }
    }
}
