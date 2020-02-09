using System;
using System.Collections.Generic;

namespace KinoDotNetCore.Models
{
    public partial class Bilety
    {
        public int Id { get; set; }
        public string StanBiletu { get; set; }
        public int SeansId { get; set; }
        public int KlientId { get; set; }

        public virtual Klienci Klient { get; set; }
        public virtual Seanse Seans { get; set; }
    }
}
