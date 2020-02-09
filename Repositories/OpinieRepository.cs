//using KinoDotNetCore.Models;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;


using KinoDotNetCore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KinoDotNetCore.Repositories
{
    public class OpinieRepository : KinoGeneric<Opinie>, IOpinieRepository
    {
        private readonly KinoContext _context;
        public OpinieRepository(KinoContext context) : base(context)
        {
            _context = context;
        }

        public List<Opinie> GetOpinieByMovieID(int filmId)
        {
            //List<Opinie> opinie = _context.Opinie.Where(x => x.FilmId == filmId).Include("Filmy").Where(s => s.FilmyId == filmId).Include("Seanse").Where(y => y.FilmyId == filmId).ToList();
            List<Opinie> opinie = _context.Opinie.Where(x => x.FilmId == filmId).Include(s => s.Film).ToList();


            return opinie;
        }
    }
}
