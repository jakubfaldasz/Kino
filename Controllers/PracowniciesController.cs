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
    public class PracowniciesController : Controller
    {
        public IUnitOfWork UnitOfWork { get; private set; }

        public PracowniciesController(IUnitOfWork unitOfWork)
        {
            this.UnitOfWork = unitOfWork;
        }

        // GET: Pracownicies
        public IActionResult Index()
        {
            return View(UnitOfWork.PracownicyRepository.GetAll().ToList());
        }

        // GET: Pracownicies/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pracownicy = UnitOfWork.PracownicyRepository.GetById((int)id);
            if (pracownicy == null)
            {
                return NotFound();
            }

            return View(pracownicy);
        }

        // GET: Pracownicies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pracownicies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Imie,Nazwisko,DataUrodzenia,DataZatrudnienia,Admin,Login,Haslo")] Pracownicy pracownicy)
        {
            if (ModelState.IsValid)
            {
                UnitOfWork.PracownicyRepository.Create(pracownicy);
                UnitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(pracownicy);
        }

        // GET: Pracownicies/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pracownicy = UnitOfWork.PracownicyRepository.GetById((int)id);

            if (pracownicy == null)
            {
                return NotFound();
            }
            return View(pracownicy);
        }

        // POST: Pracownicies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Imie,Nazwisko,DataUrodzenia,DataZatrudnienia,Admin,Login,Haslo")] Pracownicy pracownicy)
        {
            if (id != pracownicy.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    UnitOfWork.PracownicyRepository.Update(pracownicy);
                    UnitOfWork.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (UnitOfWork.PracownicyRepository.GetById(id) == null)
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
            return View(pracownicy);
        }

        // GET: Pracownicies/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pracownicy = UnitOfWork.PracownicyRepository.GetById((int)id);
            if (pracownicy == null)
            {
                return NotFound();
            }

            return View(pracownicy);
        }

        // POST: Pracownicies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var pracownicy = UnitOfWork.PracownicyRepository.GetById(id);
            UnitOfWork.PracownicyRepository.DeleteById(id);
            UnitOfWork.Save();
            return RedirectToAction(nameof(Index));
        }

    }
}
