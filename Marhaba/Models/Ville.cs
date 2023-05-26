using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Marhaba.Models
{
    public class Ville
    {
        public int Id{ get; set; }
        public String Libelle{ get; set; }

        public List<Aire> aires { get; set; }
        [NotMapped]
        public int TotalAire{ get; set; }
    }
}
