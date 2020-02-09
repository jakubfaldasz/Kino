using System;
using System.Collections.Generic;

namespace KinoDotNetCore.Models
{
    public partial class Klient
    {
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string Tytul { get; set; }
        public DateTime Dzien { get; set; }
        public DateTime Godzina { get; set; }
        public string StanBiletu { get; set; }
    }
}
