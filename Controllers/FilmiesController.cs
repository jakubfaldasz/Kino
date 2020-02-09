using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KinoDotNetCore.Models;
using KinoDotNetCore.Repositories;

namespace KinoDotNetCore.Controllers
{
    public class FilmiesController : Controller
    {
        public IUnitOfWork UnitOfWork{ get; private set; }

        public FilmiesController(IUnitOfWork unitOfWork)
        {
            this.UnitOfWork = unitOfWork;
        }


        public IActionResult Index()
        {
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

            if (opinie == null)
            {
                return NotFound();
            }

            return View(opinie);
        }


    }
}
