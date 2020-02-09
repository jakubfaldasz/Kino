using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace KinoDotNetCore.Models
{
    public partial class Filmy
    {
        public Filmy()
        {
            Opinie = new HashSet<Opinie>();
            Seanse = new HashSet<Seanse>();
        }

        public int Id { get; set; }
        [DisplayName("Tytuł")]
        public string Tytul { get; set; }
        [DisplayName("Reżyser")]
        public string Rezyser { get; set; }
        [DisplayName("Rok produkcji")]
        public short RokProdukcji { get; set; }
        public int GatunekId { get; set; }
        public int OgraniczenieId { get; set; }

        public virtual Gatunki Gatunek { get; set; }
        public virtual OgraniczeniaWiekowe Ograniczenie { get; set; }
        public virtual ICollection<Opinie> Opinie { get; set; }
        public virtual ICollection<Seanse> Seanse { get; set; }
    }
}
