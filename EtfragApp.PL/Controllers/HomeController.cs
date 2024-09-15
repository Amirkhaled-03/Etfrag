
using EtfragApp.BLL.DTOs.HomeCardMedia;
using EtfragApp.BLL.ServicesContracts;
using EtfragApp.PL.Models.Home;
using Microsoft.AspNetCore.Mvc;
using System.Buffers;
using System.Diagnostics;

namespace EtfragApp.PL.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHomeService _homeService;

        public HomeController(
            IHomeService homeService
            )
        {
            _homeService = homeService;
        }

        public IActionResult Index()
        {
            HomeVM homeVM = new HomeVM();

            homeVM.PopularMedias = _homeService.GetPopularMedias();

            homeVM.MediasOfTheYear = _homeService.GetMediasOfTheYear();

            homeVM.Movies = _homeService.GetLatestMovies();

            homeVM.TVSeries = _homeService.GetLatestTVSSeries();

            return View(homeVM);
        }


        public IActionResult AllMovies(string? searchValue = null)
        {
            IEnumerable<HomeCardMediaDto> movies;
            ViewData["SearchValue"] = searchValue;

            if (searchValue == null)
                movies = _homeService.GetLatestMovies();
            else
                movies = _homeService.GetMovieByTitle(searchValue);

            return View(movies);
        }

        public IActionResult AllTVSeries(string? searchValue = null)
        {
            IEnumerable<HomeCardMediaDto> tvseries;
            ViewData["SearchValue"] = searchValue;

            if (searchValue == null)
                tvseries = _homeService.GetLatestTVSSeries();
            else
                tvseries = _homeService.GetTVSeriesByTitle(searchValue);

            return View(tvseries);
        }

    }
}
