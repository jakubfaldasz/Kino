using KinoDotNetCore.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KinoDotNetCore.Repositories
{
    interface IKlienciRepository
    {
        bool CheckIfLoginDetailsCorrect(LoginDetails customerLoginDetails);
        int GetCustomerIdBasedOnLogin(String login);
    }
}
