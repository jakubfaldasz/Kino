using KinoDotNetCore.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KinoDotNetCore.Repositories
{
    public class SeanseRepository : KinoGeneric<Seanse>, ISeanseRepository
    {
        private readonly KinoContext _context;

        public SeanseRepository(KinoContext context) : base(context)
        {
            _context = context;
        }

        /// <summary>
        /// Pobranie Seansów danego filmu po jego id
        /// </summary>
        /// <param name="filmId"></param>
        /// <returns></returns>
        public List<Seanse> GetScreeningsByMovieID(int filmId)
        {
            List<Seanse> seanse = _context.Seanse.Where(x => x.FilmyId == filmId).Include(s => s.Filmy).Include(s => s.Sale).ToList();
            return seanse;
        }

        /// <summary>
        /// Funkcja zwracająca seanse
        /// </summary>
        /// <returns></returns>
        public List<Seanse> GetScreenings()
        {
            List<Seanse> context = _context.Seanse.Include(s => s.Filmy).Include(s => s.Sale).ToList();
            return context;
        }

        /// <summary>
        /// Funkcja zwracająca szczegółowe informacje o danym seansie
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Seanse Details(int? id)
        {
            var seanse = _context.Seanse
                .Include(s => s.Filmy)
                .Include(s => s.Sale)
                .FirstOrDefault(m => m.Id == id);
            return seanse;
        }

        /// <summary>
        /// Funkcja pobierająca model Filmy
        /// </summary>
        /// <returns></returns>
        public DbSet<Filmy> GetFilmyModel()
        {
            var filmy = _context.Filmy;
            return filmy;
        }

        /// <summary>
        /// Funkcja pobierająca model Sale
        /// </summary>
        /// <returns></returns>
        public DbSet<Sale> GetSaleModel()
        {
            var sale = _context.Sale;
            return sale;
        }

        /// <summary>
        /// Funkcja zwracająca seans po Id
        /// </summary>
        /// <param name="screeningId"></param>
        /// <returns></returns>
        public Seanse GetScreeningById(int? screeningId)
        {
            var seans = _context.Seanse
                .Include(s => s.Filmy)
                .Include(s => s.Sale)
                .FirstOrDefault(m => m.Id == screeningId);
            return seans;
        }


        public void Add(Seanse seanse)
        {
            _context.Add(seanse);
            _context.SaveChangesAsync();
        }

        public IEnumerable<SelectListItem> GetFilmySelectListItems()
        {
            IEnumerable<SelectListItem> items = _context.Filmy.Select(c => new SelectListItem
            {
                Value = "" + c.Id,
                Text = c.Tytul
            });

            return items;
        }

        public IEnumerable<SelectListItem> GetSaleSelectListItems()
        {
            IEnumerable<SelectListItem> items = _context.Sale.Select(c => new SelectListItem
            {
                Value = "" + c.Id,
                Text = "" + c.Id
            });

            return items;
        }
    }
}
