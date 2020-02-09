using KinoDotNetCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KinoDotNetCore.Repositories
{
    public class BiletyRepository: KinoGeneric<Bilety>, IBiletyRepository
    {
        private readonly KinoContext _context;

        public BiletyRepository(KinoContext context) : base(context)
        {
            _context = context;
        }

    }
}
