using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace KinoDotNetCore.Models
{
    public partial class Pracownicy
    {
        public int Id { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        [DataType(DataType.Date)]
        [DisplayName("Data urodzenia")]
        public DateTime DataUrodzenia { get; set; }
        [DataType(DataType.Date)]
        [DisplayName("Data zatrudnienia")]
        public DateTime DataZatrudnienia { get; set; }
        public string Admin { get; set; }
        public string Login { get; set; }
        [DisplayName("Hasło")]
        public string Haslo { get; set; }
    }
}
