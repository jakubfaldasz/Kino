using System;
using System.Collections.Generic;

namespace KinoDotNetCore.Models
{
    public partial class Klienci
    {
        public Klienci()
        {
            Bilety = new HashSet<Bilety>();
        }

        public int Id { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public DateTime DataUrodzenia { get; set; }
        public string AdresEmail { get; set; }
        public string Haslo { get; set; }

        public virtual ICollection<Bilety> Bilety { get; set; }
    }
}
