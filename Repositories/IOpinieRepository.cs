using KinoDotNetCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KinoDotNetCore.Repositories
{
    public interface IOpinieRepository
    {
        List<Opinie> GetOpinieByMovieID(int filmId);

    }
}
