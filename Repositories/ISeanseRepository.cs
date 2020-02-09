using KinoDotNetCore.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KinoDotNetCore.Repositories
{
    public interface ISeanseRepository
    {
        List<Seanse> GetScreeningsByMovieID(int filmId);
        List<Seanse> GetScreenings();
        Seanse Details(int? id);
        DbSet<Filmy> GetFilmyModel();
        DbSet<Sale> GetSaleModel();
        Seanse GetScreeningById(int? screeningId);
        IEnumerable<SelectListItem> GetFilmySelectListItems();
        IEnumerable<SelectListItem> GetSaleSelectListItems();
    }
}
