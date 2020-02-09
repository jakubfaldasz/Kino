using System;
using System.Collections.Generic;

namespace KinoDotNetCore.Models
{
    public partial class Format
    {
        public Format()
        {
            Sale = new HashSet<Sale>();
        }

        public int Id { get; set; }
        public string Format1 { get; set; }

        public virtual ICollection<Sale> Sale { get; set; }
    }
}
