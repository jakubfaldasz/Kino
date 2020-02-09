using KinoDotNetCore.Models;
using KinoDotNetCore.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KinoDotNetCore.Repositories
{
    public class KlienciRepository : KinoGeneric<Klienci>, IKlienciRepository
    {
        private readonly KinoContext _context;

        public KlienciRepository(KinoContext context) : base(context)
        {
            _context = context;
        }

        public bool CheckIfLoginDetailsCorrect(LoginDetails customerLoginDetails)
        {
            var customer = _context.Klienci.Where(e => e.AdresEmail == customerLoginDetails.Login && e.Haslo == customerLoginDetails.Haslo).FirstOrDefault();
            if (customer == null)
                return false;
            else
                return true;
        }

        public int GetCustomerIdBasedOnLogin(string login)
        {
            var customer = _context.Klienci.Where(e => e.AdresEmail == login).FirstOrDefault();
            if (customer == null)
                return -1;
            else
                return customer.Id;
        }
    }
}
