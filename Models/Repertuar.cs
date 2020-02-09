using System;
using System.Collections.Generic;

namespace KinoDotNetCore.Models
{
    public partial class Repertuar
    {
        public string Tytul { get; set; }
        public string Rezyser { get; set; }
        public DateTime Godzina { get; set; }
        public string _3d { get; set; }
        public string DolbyAtmos { get; set; }
        public short MinWiek { get; set; }
    }
}
