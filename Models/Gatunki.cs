using System;
using System.Collections.Generic;

namespace KinoDotNetCore.Models
{
    public partial class Gatunki
    {
        public Gatunki()
        {
            Filmy = new HashSet<Filmy>();
        }

        public int Id { get; set; }
        public string NazwaGatunku { get; set; }

        public virtual ICollection<Filmy> Filmy { get; set; }
    }
}
