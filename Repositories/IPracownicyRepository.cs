using KinoDotNetCore.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KinoDotNetCore.Repositories
{
    interface IPracownicyRepository
    {
        bool CheckIfLoginDetailsCorrect(LoginDetails employeeLoginDetails);
        bool CheckIfAdmin(LoginDetails employeeLoginDetails);
    }
}
