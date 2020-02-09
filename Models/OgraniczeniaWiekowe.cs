using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace KinoDotNetCore.Models
{
    public partial class OgraniczeniaWiekowe
    {
        public OgraniczeniaWiekowe()
        {
            Filmy = new HashSet<Filmy>();
        }

        public int Id { get; set; }
        [DisplayName("Minimalny wiek")]
        public short MinWiek { get; set; }

        public virtual ICollection<Filmy> Filmy { get; set; }
    }
}
