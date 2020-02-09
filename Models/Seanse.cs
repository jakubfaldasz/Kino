using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace KinoDotNetCore.Models
{
    public partial class Seanse
    {
        public Seanse()
        {
            Bilety = new HashSet<Bilety>();
        }

        public int Id { get; set; }
        
        [DataType(DataType.Date)]
        [DisplayName("Dzień")]
        public DateTime Dzien { get; set; }
        [DataType(DataType.Time)]
        public DateTime Godzina { get; set; }
        public int FilmyId { get; set; }
        public int SaleId { get; set; }

        public virtual Filmy Filmy { get; set; }
        public virtual Sale Sale { get; set; }
        public virtual ICollection<Bilety> Bilety { get; set; }
    }
}
