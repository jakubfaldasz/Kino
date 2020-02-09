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
    public class KliencisController : Controller
    {
        public IUnitOfWork UnitOfWork { get; private set; }

        public KliencisController(IUnitOfWork unitOfWork)
        {
            this.UnitOfWork = unitOfWork;
        }

        // GET: Kliencis
        public IActionResult Index()
        {
            return View(UnitOfWork.KlienciRepository.GetAll().ToList());
        }

        // GET: Kliencis/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var klienci = UnitOfWork.KlienciRepository.GetById((int)id);
            if (klienci == null)
            {
                return NotFound();
            }

            return View(klienci);
        }

        // GET: Kliencis/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Kliencis/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Imie,Nazwisko,DataUrodzenia,AdresEmail,Haslo")] Klienci klienci)
        {
            if (ModelState.IsValid)
            {
                UnitOfWork.KlienciRepository.Create(klienci);
                UnitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(klienci);
        }

        // GET: Kliencis/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var klienci = UnitOfWork.KlienciRepository.GetById((int)id);
            if (klienci == null)
            {
                return NotFound();
            }
            return View(klienci);
        }

        // POST: Kliencis/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Imie,Nazwisko,DataUrodzenia,AdresEmail,Haslo")] Klienci klienci)
        {
            if (id != klienci.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    UnitOfWork.KlienciRepository.Update(klienci);
                    UnitOfWork.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (UnitOfWork.KlienciRepository.GetById(id) == null)
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
            return View(klienci);
        }

        // GET: Kliencis/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var klienci = UnitOfWork.KlienciRepository.GetById((int)id);
            if (klienci == null)
            {
                return NotFound();
            }

            return View(klienci);
        }

        // POST: Kliencis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var klienci = UnitOfWork.KlienciRepository.GetById(id);
            UnitOfWork.KlienciRepository.DeleteById(id);
            UnitOfWork.Save();
            return RedirectToAction(nameof(Index));
        }

    }
}
