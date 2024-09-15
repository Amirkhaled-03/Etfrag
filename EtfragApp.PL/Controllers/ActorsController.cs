
using EtfragApp.BLL.DTOs.Actor;
using EtfragApp.BLL.DTOs.Pages;
using EtfragApp.BLL.ServicesContracts;
using EtfragApp.DAL.Entities;
using EtfragApp.PL.Models.Actor;
using EtfragApp.PL.Models.Page;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Buffers;


namespace EtfragApp.PL.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ActorsController : Controller
    {
        private readonly IActorService _actorService;

        public ActorsController(IActorService actorService)
        {
            _actorService = actorService;
        }
        public IActionResult Index(int pageSize = 7, int pageNo = 1, bool needCount = true, string? searchValue = null)
        {
            // Store the search value in ViewData to keep it in the form
            ViewData["SearchValue"] = searchValue;

            return View(GetPage(pageSize, pageNo, needCount, searchValue));
        }

        public IActionResult Create()
        {

            return View(new ActorVM());
        }

        [HttpPost]
        public IActionResult Create(ActorVM model)
        {
            if (ModelState.IsValid)
            {
                CreateActorDto actor = new CreateActorDto
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Nationality = model.Nationality,
                    ProfilePicture = model.ProfilePicture,
                };


                _actorService.Add(actor);

                return RedirectToAction("Index", "Actors");
            }
            return View(model);
        }

        public IActionResult Delete(int id)
        {
            var actor = _actorService.GetById(id);

            if (actor != null)
            {
                _actorService.Delete(id);
            }

            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            var actor = _actorService.GetById(id);
            if (actor == null)
                return NotFound();

            ActorVM mappedActor = new ActorVM
            {
                FirstName = actor.FirstName,
                LastName = actor.LastName,
                Nationality = actor.Nationality,
                ImageURL = actor.ProfilePictureUrl
            };

            return View(mappedActor);
        }

        [HttpPost]
        public IActionResult Update(int id, ActorVM model)
        {
            Actor actor = _actorService.GetById(id);
            if (actor is null)
                return NotFound();

            EditActorDto actor1 = new EditActorDto
            {
                Id = actor.ActorId,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Nationality = model.Nationality,
                ProfilePicture = model.ProfilePicture,
            };

            _actorService.Update(actor1);

            return RedirectToAction("Index", "Actors");
        }

        public PageDataVM<ActorTableVM> GetPage(int pageSize, int pageNo, bool needCount, string? searchValue)
        {
            ActorTableVM actorVM;
            List<ActorTableVM> mappedActors = new List<ActorTableVM>();
            PageData<ActorDto> actorsPageData;

            if (searchValue is null)
                actorsPageData = _actorService.Getpage(pageSize, pageNo, needCount);
            else
                actorsPageData = _actorService.GetPageWithSearch(pageSize, pageNo, needCount, searchValue);

            foreach (var actor in actorsPageData.Data)
            {
                actorVM = new ActorTableVM()
                {
                    Id = actor.ActorId,
                    FirstName = actor.FirstName,
                    LastName = actor.LastName,
                    Nationality = actor.Nationality,
                    ImageURL = actor.ProfilePictureUrl,
                    AddedAt = actor.AddedAt
                };

                actorVM.TotalSeriesInSite = _actorService.GetTotalActorSeriesCount(actor.ActorId);
                actorVM.TotalFilmsInSite = _actorService.GetTotalActorFilmsCount(actor.ActorId);

                mappedActors.Add(actorVM);
            }

            return new PageDataVM<ActorTableVM>
            {
                Data = mappedActors,
                PageNumber = pageNo,
                PageSize = pageSize,
                TotalRecords = actorsPageData.TotalRecords,
            };
        }
    }
}