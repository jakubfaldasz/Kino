using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KinoDotNetCore.Models;
using KinoDotNetCore.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace KinoDotNetCore.Controllers
{
    public class CustomerPanelController : Controller
    {
        public IUnitOfWork UnitOfWork { get; private set; }
        private static int loggedUserId;

        public CustomerPanelController(IUnitOfWork unitOfWork)
        {
            this.UnitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            loggedUserId = int.Parse(TempData["UserId"].ToString());
            List<Filmy> movies = UnitOfWork.FilmyRepository.GetAll();
            return View(movies);
        }

        public IActionResult ShowSeanse(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }


            var seanse = UnitOfWork.SeanseRepository.GetScreeningsByMovieID((int)id);

            if (seanse == null)
            {
                return NotFound();
            }

            return View(seanse);
        }

        public IActionResult ShowOpinie(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var opinie = UnitOfWork.OpinieRepository.GetOpinieByMovieID((int)id);
            var movieTitle = UnitOfWork.FilmyRepository.GetById((int)id).Tytul;

            if (opinie == null)
            {
                return NotFound();
            }

            ViewData["IdFilmu"] = id;
            ViewData["TytulFilmu"] = movieTitle;

            return View(opinie);
        }


        public IActionResult AddOpinion(int? id)
        {
            ViewData["FilmId"] = id;
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddOpinion([Bind("Ocena, TrescOpinii, FilmId")] Opinie opinia)
        {
            if (ModelState.IsValid)
            {
                UnitOfWork.OpinieRepository.Create(opinia);
                UnitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View("AddOpinion");
        }


        public IActionResult BuyTicket(int? id)
        {
            Bilety bilet = new Bilety
            {
                StanBiletu = "zapłacony",
                SeansId = (int)id,
                KlientId = loggedUserId,
                Klient = UnitOfWork.KlienciRepository.GetById(loggedUserId),
                Seans = UnitOfWork.SeanseRepository.GetById((int)id)
            };

            UnitOfWork.BiletyRepository.Create(bilet);
            UnitOfWork.Save();
            
            return View(bilet);
        }

    }
}