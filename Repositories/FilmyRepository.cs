using KinoDotNetCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KinoDotNetCore.Repositories
{
    public class FilmyRepository: KinoGeneric<Filmy>, IFilmyRepository
    {
        private readonly KinoContext _context;
        public FilmyRepository(KinoContext context) : base(context)
        {
            _context = context;
        }
    }
}
