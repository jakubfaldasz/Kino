using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace KinoDotNetCore.Models
{
    public partial class Sale
    {
        public Sale()
        {
            Seanse = new HashSet<Seanse>();
        }

        [DisplayName("Nr sali")]
        public int Id { get; set; }
        [DisplayName("3D")]
        public string Has3D { get; set; }
        [DisplayName("Dolby Atmos")]
        public string HasDolbyAtmos { get; set; }
        public int FormatId { get; set; }
        [DisplayName("Ilość Miejsc")]
        public int IloscMiejsc { get; set; }
        [DisplayName("Ilość dost. miejsc")]
        public int IloscDostMiejsc { get; set; }

        public virtual Format Format { get; set; }
        public virtual ICollection<Seanse> Seanse { get; set; }
    }
}
