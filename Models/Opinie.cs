using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace KinoDotNetCore.Models
{
    public partial class Opinie
    {
        public int Id { get; set; }
        public float Ocena { get; set; }
        [DisplayName("Treść opinii")]

        public string TrescOpinii { get; set; }
        public int FilmId { get; set; }

        public virtual Filmy Film { get; set; }
    }
}
