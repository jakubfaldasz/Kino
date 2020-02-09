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
    public class SeansesController : Controller
    {
        public IUnitOfWork UnitOfWork { get; set; }

        public SeansesController(IUnitOfWork unitOfWork)
        {
            this.UnitOfWork = unitOfWork;
        }

        // GET: Seanses
        public IActionResult Index()
        {
            var seanse = UnitOfWork.SeanseRepository.GetScreenings();
            return View(seanse);
        }

        // GET: Seanses/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var seanse = UnitOfWork.SeanseRepository.Details(id);

            if (seanse == null)
            {
                return NotFound();
            }

            return View(seanse);
        }


        // GET: Seanses/Create
        public IActionResult Create()
        {
            ViewData["FilmyId"] = UnitOfWork.SeanseRepository.GetFilmySelectListItems();
            ViewData["SaleId"] = UnitOfWork.SeanseRepository.GetSaleSelectListItems();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Dzien,Godzina,FilmyId,SaleId")] Seanse seanse)
        {
            if (ModelState.IsValid)
            {
                UnitOfWork.SeanseRepository.Create(seanse);
                UnitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View("Index");
        }

        // GET: Seanses/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var seanse = UnitOfWork.SeanseRepository.GetScreeningById(id);
            if (seanse == null)
            {
                return NotFound();
            }
            ViewData["FilmyId"] = new SelectList(UnitOfWork.SeanseRepository.GetFilmyModel(), "Id", "Tytul", seanse.FilmyId);
            ViewData["SaleId"] = new SelectList(UnitOfWork.SeanseRepository.GetSaleModel(), "Id", "Id", seanse.SaleId);
            return View(seanse);
        }

        // POST: Seanses/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Dzien,Godzina,FilmyId,SaleId")] Seanse seanse)
        {
            if (id != seanse.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    UnitOfWork.SeanseRepository.Update(seanse);
                    UnitOfWork.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (UnitOfWork.SeanseRepository.GetById(seanse.Id) == null)
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(seanse);
        }

        // GET: Seanses/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var seanse = UnitOfWork.SeanseRepository.GetScreeningById(id);

            if (seanse == null)
            {
                return NotFound();
            }

            return View(seanse);
        }

        // POST: Seanses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var seanse = UnitOfWork.SeanseRepository.GetById(id);
            if(seanse != null)
            {
                UnitOfWork.SeanseRepository.DeleteById(id);
                UnitOfWork.Save();
            }
            return RedirectToAction(nameof(Index));
        }

    }
}
